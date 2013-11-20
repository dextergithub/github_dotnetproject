using System;
using System.Collections.Generic;
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
        HttpWebRequest Request = null;
        HttpWebResponse Response
        {
            get
            {

                ExceptionHelper.NullIf(this.Request);
                return (HttpWebResponse)this.Request.GetResponse();
            }
        }



        public HttpHelper()
        {

        }

        public HttpHelper SetUrl(Uri uri)
        {
            this.Request = (HttpWebRequest)WebRequest.CreateHttp(uri);           
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
            string txt = GetText(Encoding.ASCII);
            return txt;
        }


        public static string HttpGet(string url)
        {
            string responsetxt = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));

            return responsetxt;
        }

    }
}
