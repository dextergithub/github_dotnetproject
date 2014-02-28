using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace QQAutoSend
{
    internal class Regedit
    {
        private static string _License = "License";
        private static string _RegKey = "SOFTWARE\\bmpj.net";

        internal static bool IsRegKeyExist
        {
            get
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(_RegKey);
                if (key == null) return false;
                else { key.Close(); return true; }
            }
        }

        internal static string LicenseKey
        {
            get
            {
                object obj = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + _RegKey, _License, "");
                if (obj == null) return String.Empty;
                else return obj.ToString();
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\" + _RegKey, _License, value);
            }
        }

    }
}
