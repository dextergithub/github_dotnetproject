using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseCommon;

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
                if(!string.IsNullOrEmpty(par) && par.IndexOf("ui", StringComparison.OrdinalIgnoreCase)>=0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());

                }

                Vendor vendor = new Vendor();
                vendor.SetPortName(ModbusSample.Properties.Settings.Default.ComName);

                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;

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
                                    vendor.OutputGoods(ModbusSample.Properties.Settings.Default.ProductA, (flag) =>
                                    {
                                        log.WriteDebugLog("出货A：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ModbusSample.Properties.Settings.Default.ProductA));
                                        Console.WriteLine("出货A:" + (flag ? "成功" : "失败"));
                                    });
                                    break;
                                case "B":
                                    vendor.OutputGoods(ModbusSample.Properties.Settings.Default.ProductB, (flag) =>
                                    {
                                        log.WriteDebugLog("出货B：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ModbusSample.Properties.Settings.Default.ProductB));
                                        Console.WriteLine("出货B:" + (flag ? "成功" : "失败"));
                                    });
                                    break;
                                default:
                                    break;
                            }

                        }
                        catch (Exception exin)
                        {
                            log.Error(exin.Message, exin);
                        }
                        
                        if(txt =="exit")
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
    }
}
