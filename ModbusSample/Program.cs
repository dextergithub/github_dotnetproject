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

                string par = System.Environment.CommandLine;
                if (!string.IsNullOrEmpty(par) && par.IndexOf("ui", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());

                }

                Vendor vendor = new Vendor();
                if (!vendor.SetPortName(ModbusSample.Properties.Settings.Default.ComName))
                {
                    log.WriteDebugLog(ModbusSample.Properties.Settings.Default.ComName + " 连接:打开串口错误!");

                }

                log.WriteDebugLog(ModbusSample.Properties.Settings.Default.ComName + "连接:" + (vendor.CommIsOk ? "通读正常" : "通读异常"));
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                log.WriteDebugLog("设置编码正常！开始读取指令！");
               
                Task readerTast = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        string txt = Console.ReadLine();
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

            if (!GetIndex(Idx, ref  goodid))
            {
                Console.WriteLine("出货" + Idx + ":" + "失败");
                log.Error("出货" + Idx + ":" + "失败", "Program", "OutPutGoods");
                return;
            }

            if (Vendor.ModbusData[Vendor.CurrRunningMotorIndex] != 255)
            {
                MessageBox.Show("上一次出货任务还未完成，请稍候。");
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
            string configPChannels = P + "Channels";
            string strchannels = "";
            if (P == "B")
            {
                strchannels = Properties.Settings.Default.BChannels;
                current = Properties.Settings.Default.BCurrent;
            }
            else if (P == "A")
            {
                strchannels = Properties.Settings.Default.AChannels;
                current = Properties.Settings.Default.ACurrent;
            }

            Per = Properties.Settings.Default.PerChannel;

            if (string.IsNullOrEmpty(strchannels))
            {
                Log.log.Error(configPChannels + "Channels 参数没有配置！", null);
                Index = -1;
                return false;
            }
            string[] clists = strchannels.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (clists == null || clists.Length != 2)
            {
                Log.log.Error(configPChannels + "配置不正确，" + strchannels + "(1-2)", "Program", MethodBase.GetCurrentMethod().Name);
            }

            int.TryParse(clists[0], out channelstart);
            int.TryParse(clists[1], out channelend);

            int total = ((channelend - channelstart) + 1) * Per;

            int startIndex = channelstart * Per;
            int endIndex = (channelend + 1) * Per;

            if (startIndex + current < endIndex)
            {
                Index = startIndex + current;
                if (P == "A")
                {
                    Properties.Settings.Default.ACurrent = Index + 1;
                }
                else if (P == "B")
                {
                    Properties.Settings.Default.BCurrent = Index + 1;
                }
                Properties.Settings.Default.Save();
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
