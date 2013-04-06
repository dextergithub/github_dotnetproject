using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json.Serialization;

namespace KinectCore
{
    public class RequestItem
    {
        [Newtonsoft.Json.JsonIgnore()]
        public Socket SrcSocket { get; set; }

        public string Commond { get; set; }

        public string GrammarFile { get; set; }

        public long NO { get; set; }

        public int Confidence { get; set; }

        public string Recognized { get; set; }

        public byte[] Serializ()
        {
            string txt = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return System.Text.Encoding.Default.GetBytes(txt);
        }

        public byte[] SerializResult()
        {
            return System.Text.Encoding.Default.GetBytes("{{\"NO\":{0},\"Confidence\":{1},\"Recognized\":\"{2}\"}}".ExtFormat(this.NO ,this.Confidence,this.Recognized ));
        }

        public static RequestItem Deserialize(byte[] b)
        {
            string txt = System.Text.Encoding.Default.GetString(b);
            Log.log.WriteDebugLog("反序列化：" + txt);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<RequestItem>(txt);
        }

    }
}
