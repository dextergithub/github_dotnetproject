using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseCommon;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace ModbusSample
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Log log = Log.GetInstance();

            try
            {
                VEMConfigHelper config = VEMConfigHelper.Create();

                string par = System.Environment.CommandLine;
                if (!string.IsNullOrEmpty(par) && par.IndexOf("show_ui", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new TestForm1());
                    return;

                }

                Vendor vendor = new Vendor();
                if (!vendor.SetPortName(config.Port))
                {
                    log.WriteDebugLog(config.Port + " 连接:打开串口错误!");

                }

                log.WriteDebugLog(config.Port + "连接:" + (vendor.CommIsOk ? "通读正常" : "通读异常"));
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                log.WriteDebugLog("设置编码正常！开始读取指令！");

                Task readerTast = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        string txt = Console.In.ReadLine();
                        log.WriteDebugLog("获取指令：" + txt);
                        try
                        {
                            switch (txt)
                            {
                                case "A":
                                    OutPutGoods(vendor, "A", log);
                                    break;
                                case "B":
                                    OutPutGoods(vendor, "B", log);
                                    break;
                                case "exit":
                                    Application.Exit();
                                    break;
                                default:
                                    break;
                            }

                        }
                        catch (Exception exin)
                        {
                            log.Error(exin.Message, exin);
                        }

                        if (txt == "exit")
                        {
                            break;
                        }

                    }

                    log.WriteDebugLog("退出读取指令线程！");
                });


                readerTast.Wait();


            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }

        }

        public static void OutPutGoods(Vendor Vendor, string Idx, Log log)
        {
            int goodid = -1;

            System.Threading.Thread.Sleep(2000);

            if (!GetIndex(Idx, ref  goodid))
            {
                Console.WriteLine("出货" + Idx + ":" + "失败");
                log.Error("出货" + Idx + ":" + "失败", "Program", "OutPutGoods");
                return;
            }

            if (!Vendor.CommIsOk)
            {
                Console.WriteLine("目前系统通讯故障。");
                log.WriteDebugLog("目前系统通讯故障。");
                return;
            }
            if (Vendor.ModbusData[Vendor.CurrRunningMotorIndex] != 255)
            {
                Console.WriteLine("上一次出货任务还未完成，请稍候。");
                log.WriteDebugLog("上一次出货任务还未完成，请稍候。");
                return;
            }

            Vendor.OutputGoods(goodid, (flag) =>
            {
                log.WriteDebugLog("出货" + Idx + "：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", goodid));
                Console.WriteLine("出货" + Idx + ":" + (flag ? "成功" : "失败"));
            });

        }

        public static bool GetIndex(string P, ref int Index)
        {
            int channelstart = 0, channelend = 0, current = 0, Per = 0;
            VEMConfigHelper config = VEMConfigHelper.Create();
            List<ChannelInfo> channnels = new List<ChannelInfo>();


            if (P == "B")
            {
                current = config.BCurrent;
                channnels = config.GetProductBChannels();
            }
            else if (P == "A")
            {
                current = config.ACurrent;
                channnels = config.GetProductAChannels();
            }

            if (channnels != null && channnels.Count > 0)
            {

                var chan = channnels.First(p => { return p.IndexE >= current && p.IndexS <= current; });
                if (chan == null)
                {
                    Index = -1;
                    return false;
                }
                else
                {
                    Index = chan.ID;
                }

                if (P == "A")
                {
                    config.ACurrent = current + 1;
                }
                else if (P == "B")
                {
                    config.BCurrent = current + 1;
                }
                config.Save();
                return true;
            }
            else
            {
                Log.log.Error(P + "商品已经用完了", "Progam", MethodBase.GetCurrentMethod().Name);
                Index = -1;
                return false;
            }


        }

    }
}
