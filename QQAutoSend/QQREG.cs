using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
//Download by http://www.codefans.net
namespace QQAutoSend
{
    internal class QQREG
    {
        private static string CPUID
        {
            get
            {
                string id = String.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    id = mo["processorid"].ToString();
                    if (id != String.Empty)
                        break;
                }
                return id;
            }
        }

        internal static string MachineKey
        {
            get
            {
                string cpuid = CPUID;
                string desen = DES.DESEncrypt(cpuid, "LSJWQ)#!!)*", ")#!!)**)!!#)");
                return desen;
                //return DES.EnFormatCrypt(desen.Substring(0, 16), 4);
            }
        }


        internal static string CreateLicense(string machinekey)
        {
            try
            {
                string license = DES.DESEncrypt(machinekey, "*%)$@*scalelsjwq", "scalelsjwq*%)$@*");
                return license;
                //return DES.EnFormatCrypt(license, 8);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        internal static string AnalysisLicense(string Lic)
        {
            try
            {
                string machinekey = DES.DESDecrypt(Lic, "*%)$@*scalelsjwq", "scalelsjwq*%)$@*");
                return machinekey;
            }
            catch
            {
                return string.Empty;
            }


        }

        internal static bool IsRegSoftware
        {
            get
            {
                try
                {
                    return true;
                    string lickey = Regedit.LicenseKey;
                    if (lickey.Equals(String.Empty)) return false;

                    if (AnalysisLicense(lickey).Equals(MachineKey))
                        return true;
                    else
                        return false;
                }
                catch 
                {
                    return false;
                }
               
            }
        }
    }
}
