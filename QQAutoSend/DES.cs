using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
//Download by http://www.codefans.net
namespace QQAutoSend
{
    internal class DES
    {
        internal static string DESEncrypt(string encryptString, string KEY, string IV) //º”√‹
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(KEY.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(IV.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                //return Convert.ToBase64String(mStream.ToArray());

                StringBuilder sb = new StringBuilder();
                byte[] bytes = mStream.ToArray();
                foreach (byte b in bytes)
                {
                    //string tmp = Convert.ToString(b, 16).ToUpper ();
                    sb.AppendFormat("{0:X2}", b);
                }
                return sb.ToString();
            }
            catch 
            {
                return encryptString;
            }
        }



        internal static string DESDecrypt(string decryptString, string KEY, string IV) //Ω‚√‹
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(KEY.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(IV.Substring(0, 8));

                //byte[] inputByteArray = Convert.FromBase64String(decryptString);


                int count = decryptString.Length / 2;
                byte[] inputByteArray = new byte[count];
                for (int i = 0; i < count; i++)
                {
                    string tmp = decryptString.Substring(i * 2, 2);
                    inputByteArray[i] = Convert.ToByte(tmp, 16);
                }

                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }


        public static string EnFormatCrypt(string encrypted, int onegroupcount)
        {
            //string format = String.Empty;
            //format = encrypted.Substring(0, 8) + "-" + encrypted.Substring(8, 8) + "-" + encrypted.Substring(16, 8) + "-" + encrypted.Substring(24, 8);
            //return format;

            string format = String.Empty;
            string sub = String.Empty;
            for (int i = 0; i < encrypted.Length; i++)
            {
                sub += encrypted[i];
                if (sub.Length == onegroupcount || i == encrypted.Length - 1)
                {
                    format += sub;
                    if (i != encrypted.Length - 1)
                        format += "-";
                    sub = String.Empty;
                }

            }
            return format;
        }

        public static string DeFormatCrypt(string formated)
        {
            string tmp = formated;
            int index = -1;
            while ((index = tmp.IndexOf("-")) >= 0)
            {
                tmp = tmp.Replace("-", "");
            }
            return tmp;
        }

    }
}
