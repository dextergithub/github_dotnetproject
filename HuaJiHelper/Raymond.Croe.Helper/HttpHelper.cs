using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Raymond.Croe.Helper
{
    public class HttpHelper
    {
        HttpWebRequest _request = null;
        HttpWebRequest Request
        {
            get
            {
                if (_request != null)
                {
                    _request = HttpGet(this.Uri);
                }
                return _request;
            }
        }

        public HttpHelper GetRequest(bool reget)
        {
            if (reget)
                _request = HttpGet(this.Uri);
            else if (_request == null)
            {
                _request = HttpGet(this.Uri);
            }
            return this;

        }
        HttpWebResponse _Respone = null;
        HttpWebResponse Response
        {
            get
            {
                if (_Respone != null)
                {
                    return _Respone;
                }
                
                int time = 1;
                do
                {
                    try
                    {
                        _Respone = (HttpWebResponse)this.GetRequest(true).Request .GetResponse();
                        if (_Respone.StatusCode != HttpStatusCode.OK)
                        {
                            time++;
                        }
                        else
                        {
                            return _Respone;
                        }
                    }
                    catch (Exception)
                    {
                        time++;
                    }

                    System.Threading.Thread.Sleep(1000);
                } while (time < ReTryCount && time != 1);

                return _Respone;
            }
        }



        public HttpHelper()
        {

        }
        public int ReTryCount = 3;

        public HttpHelper SetTryCount(int count)
        {
            if (count <= 0) count = 1;
            this.ReTryCount = count;
            return this;
        }

        private Uri Uri { get; set; }

        public HttpHelper SetUrl(Uri uri)
        {
            this.Uri = uri;
            return this;
        }
        public Stream ResponseStream()
        {
            ExceptionHelper.NullIf(this.Response);
            return this.Response.GetResponseStream();
        }



        public string GetText(Encoding encoding)
        {
            StreamReader reader = null;
            if (this.Response.StatusCode == HttpStatusCode.OK)
            {
                if (Response.ContentEncoding != null &&
                    Response.ContentEncoding.Equals("gzip",
                    StringComparison.InvariantCultureIgnoreCase))
                    reader = new StreamReader(new GZipStream(Response.GetResponseStream(), CompressionMode.Decompress));
                else
                    reader = new StreamReader(Response.GetResponseStream(), encoding);

            }


            string txt = string.Empty;
            if (reader != null)
            {
                txt = reader.ReadToEnd();
            }

            return txt;
        }

        public string GetText()
        {
            string txt = GetText(Encoding.UTF8);
            return txt;
        }


        public static HttpWebRequest HttpGet(Uri url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault((url));
            return request;
        }

    }
}
