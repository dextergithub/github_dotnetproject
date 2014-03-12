using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using Modbus.Device;
using BaseCommon;
using System.Reflection;

namespace ModbusSample
{
    public class Vendor
    {
        private ModbusMaster modbusMaster;
        private readonly ushort[] modbusData = new ushort[400];
        private ushort changeTaskId = 1;
        private const byte Slave = 1;
        private ConcurrentQueue<Action> modbusTaskQueue = new ConcurrentQueue<Action>();
        private readonly SerialPort serialPort;
        private Task modbusTask;
        private bool commIsOk = true;
        private bool inited = false;
        private int lastMoneyInserted;
        private int lastChangeRequestCount = 0;
        /// <summary>
        /// 找零标记
        /// </summary>
        public const int ChangeIsBusyIndex = 37;
        /// <summary>
        /// Mdb硬币器
        /// </summary>
        public const int MdbChangerEanbleIndex = 38;
        /// <summary>
        /// Mdb纸币器 状态
        /// </summary>
        public const int MdbNoteEnableIndex = 39;
        /// <summary>
        /// 1#脉冲收币器
        /// </summary>
        public const int Pulse1EnableIndex = 40;
        /// <summary>
        /// 2#脉冲收币器
        /// </summary>
        public const int Pulse2EanableIndex = 41;
        public const int CurrRunningMotorIndex = 42;

        public Vendor()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.ReadTimeout = 300;
            serialPort.WriteTimeout = 200;
            SetPortName("com1");
            modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);

            modbusTask = new Task(ModbusWorkTask);
            modbusTask.Start();
        }

        public event EventHandler ChangeRequest;

        /// <summary>
        /// 后台工作线程
        /// </summary>
        private void ModbusWorkTask()
        {
            while (true)
            {
                Action result;
                if (!modbusTaskQueue.TryDequeue(out result))
                {
                    result = IdleTask;
                }
                result();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 后台线程空闲时执行的任务
        /// </summary>
        /// <returns></returns>
        private void IdleTask()
        {
            bool r = false;
            int moneyInserted = 0;
            if (!inited)
            {
                inited = ReadData(300, 100);
                Thread.Sleep(50);

                inited &= ReadData(200, 100);
                Thread.Sleep(50);

                inited &=ReadData(0, 14);
                Thread.Sleep(50);

                inited &= ReadData(30, 13);
                Thread.Sleep(50);
                // 记录下系统中当前有多少钱
                lastMoneyInserted = modbusData[30] * 0x65535 + modbusData[31];
                // 记录下找零请求次数
                lastChangeRequestCount = modbusData[31];
            }
            else
            {
                // 系统信息
                ReadData(0, 14);
                Thread.Sleep(50);
                // 支付系统信息
                r = ReadData(30, 13);
                // 检查是否收到钱
                moneyInserted = modbusData[30] * 0x65535 + modbusData[31];
                if (inited && moneyInserted > lastMoneyInserted)
                {
                    InsertedMoney += (decimal)(moneyInserted - lastMoneyInserted) / 100;
                }
                if(r)
                {
                    lastMoneyInserted = moneyInserted;
                }
                
                // 检查是否请求找钱
                if(modbusData[32] > lastChangeRequestCount)
                {
                    OnChangeRequest();
                }
                if(r)
                {
                    lastChangeRequestCount = modbusData[32];
                }

                Thread.Sleep(50);
            }
        }

        private void OnChangeRequest()
        {
            if(ChangeRequest != null)
            {
                ChangeRequest(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 尝试设置并打开串口
        /// </summary>
        /// <param name="portName"></param>
        public bool SetPortName(string portName)
        {
            lock (serialPort)
            {
                try
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                    serialPort.PortName = portName;
                    serialPort.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Log.log.Error(this.GetType().Name+"_"+ MethodBase.GetCurrentMethod().Name, ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 返回串口对象
        /// </summary>
        public SerialPort SerialPort
        {
            get { return serialPort; }
        }

        /// <summary>
        /// 指示后台通读是否正常
        /// </summary>
        public bool CommIsOk
        {
            get { return commIsOk; }
        }

        /// <summary>
        /// 返回Modbus数据
        /// </summary>
        public ushort[] ModbusData
        {
            get { return modbusData; }
        }

        /// <summary>
        /// 用户总的币数,以元为单位
        /// </summary>
        public decimal InsertedMoney { get; set; }

        /// <summary>
        /// 找零的总数，以元为单位
        /// </summary>
        public decimal RestChange { get { return modbusData[05] / 100; } }

        /// <summary>
        /// 执行找零工作
        /// </summary>
        /// <param name="money"></param>
        /// <param name="onFinishiCallback"> </param>
        public void Change(double money, Action<double> onFinishiCallback)
        {
            if (onFinishiCallback == null) throw new ArgumentNullException("onFinishiCallback");
            if (money <= 0) throw new ArgumentOutOfRangeException("money");

            // 找零器正忙
            if (modbusData[ChangeIsBusyIndex] != 0)
            {
                onFinishiCallback(0);
            }

            Action action = delegate
                                {
                                    bool r = true;
                                    r = WriteData(34, (ushort)(money * 100), changeTaskId++);
                                    if (!r)
                                    {
                                        onFinishiCallback(0);
                                        return;
                                    }
                                    Thread.Sleep(2000);
                                    int passedTime = 0;
                                    while (passedTime < 60)
                                    {
                                        r = ReadData(34, 4);
                                        if (!r)
                                        {
                                            onFinishiCallback(0);
                                            return;
                                        }

                                        if (modbusData[ChangeIsBusyIndex] == 0)
                                        {
                                            onFinishiCallback(modbusData[36]);
                                            return;
                                        }
                                        Thread.Sleep(1000);
                                        passedTime++;
                                    }
                                    //超时
                                    onFinishiCallback(0);
                                };

            modbusTaskQueue.Enqueue(action);
        }

        /// <summary>
        /// 写Modbus数据
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void WriteModusData(ushort index, int data)
        {
            Action action = delegate
                                {
                                    WriteData(index, (ushort)data);
                                };
            modbusTaskQueue.Enqueue(action);
        }

        /// <summary>
        /// 更新modubs数据
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public void RefreshModbusData(ushort index, ushort length)
        {
            Action action = delegate
                                {
                                    ReadData(index, length);
                                };
            modbusTaskQueue.Enqueue(action);
            
        }

        /// <summary>
        /// 执行出货任务
        /// </summary>
        /// <param name="index"></param>
        /// <param name="onOutputFinnish"></param>
        public void OutputGoods(int index, Action<bool> onOutputFinnish)
        {
            if (onOutputFinnish == null) throw new ArgumentNullException("onOutputFinnish");
            if (index < 0 || index >= 72) throw new ArgumentOutOfRangeException("index");
            if (modbusData[42] != 255)
            {
                onOutputFinnish(false);
                return;
            }

            Action action = delegate
            {
                bool r = false;

                // 检查是否有电机正在测试
                r = ReadData(42, 1);
                if (!r || modbusData[42] != 255)
                {
                    onOutputFinnish(false);
                    return;
                }
                Thread.Sleep(100);

                // 检查电机故障代码
                ReadData((ushort)(300 + index), 1);
                if (!r || modbusData[300 + index] != 0)
                {
                    onOutputFinnish(false);
                    return;
                }
                Thread.Sleep(100);

                // 读电机启动次数
                r = ReadData((ushort)(200 + index), 1);
                int runTimes = modbusData[200 + index];
                if (!r)
                {
                    onOutputFinnish(false);
                    return;
                }
                Thread.Sleep(100);

                // 启动电机
                r = WriteData((ushort)(100 + index), 1);
                if (!r)
                {
                    onOutputFinnish(false);
                    return;
                }
                Thread.Sleep(100);

                // 等待直到电机启动次数发生变化
                while (true)
                {
                    // 读当前启动的货道
                    ReadData(42, 1);
                    Thread.Sleep(50);
                    // 读启动次数
                    ReadData((ushort)(200 + index), 1);
                    if (!r || runTimes != modbusData[200 + index])
                        break;
                    Thread.Sleep(50);
                }

                // 检测故障代码
                ReadData((ushort)(300 + index), 1);
                var isSuccess = r && modbusData[300 + index] == 0;
                onOutputFinnish(isSuccess);
            };
            modbusTaskQueue.Enqueue(action);
        }

        /// <summary>
        /// 读取Modbus数据并将结果复制到ModbusData中
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="length"></param>
        private bool ReadData(ushort startAddress, ushort length)
        {
            try
            {
                lock (serialPort)
                {
                    var data = modbusMaster.ReadHoldingRegisters(Slave, startAddress, length);
                    data.CopyTo(modbusData, startAddress);
                    commIsOk = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.log.Error(this.GetType().FullName +","+ MethodBase.GetCurrentMethod().Name ,ex);
                commIsOk = false;
                return false;
            }
        }

        /// <summary>
        /// 写Modbus数据
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="data"></param>
        private bool WriteData(ushort startAddress, params ushort[] data)
        {
            try
            {
                lock (serialPort)
                {
                    modbusMaster.WriteMultipleRegisters(Slave, startAddress, data);
                    commIsOk = true;
                    return true;
                }
            }
            catch (Exception)
            {
                commIsOk = false;
                return false;
            }
        }

    }
}