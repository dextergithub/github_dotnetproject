using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BaseCommon;

namespace ModbusSample
{
    public class VEMConfigHelper
    {
        private string filename = "";
        private XDocument doc = null;
        private VEMConfigHelper(string path)
        {
            filename = path;
            doc = XDocument.Load(path);
        }

        private static VEMConfigHelper _VEMConfigHelper = null;
        public static VEMConfigHelper Create()
        {
            if (_VEMConfigHelper == null)
            {
                _VEMConfigHelper = new VEMConfigHelper(System.Configuration.ConfigurationManager.AppSettings["VEMConfig"]);
            }
            return _VEMConfigHelper;
        }

        public void Save()
        {
            doc.Save(filename);
        }
        /*
        public int GetNoteValue(bool defaultnote, string p, string key)
        {
            string value = doc.Root.Element(defaultnote ? "Default" : "Instance").Elements("Product").FirstOrDefault((n) =>
            {
                return n.Attribute("ID").Value == p;
            }).Element(key).Value;
            int intvalue = 0;
            int.TryParse(value, out intvalue);
            return intvalue;
        }
        */
        private string GetPort()
        {
            string value = doc.Root.Element("Default").Element("Com").Value;
            return value;
        }

        private void SetPort(string com)
        {
            doc.Root.Element("Default").Element("Com").Value = com;
        }
        /*
        public void SetNoteValue(bool defaultnote, string p, string key, object value)
        {
            doc.Root.Element(defaultnote ? "Default" : "Instance").Elements("Product").FirstOrDefault((n) =>
            {
                return n.Attribute("ID").Value == p;
            }).Element(key).SetValue(value);
        }
         * */
        /*
        #region B
        public int BChannelStart
        {
            get { return GetNoteValue(false, "B", "ChannelStart"); }
            set { SetNoteValue(false, "B", "ChannelStart", value); }
        }

        public int BChannelEnd
        {
            get { return GetNoteValue(false, "B", "ChannelEnd"); }
            set { SetNoteValue(false, "B", "ChannelEnd", value); }
        }

        public int BPerChannel
        {
            get { return GetNoteValue(false, "B", "PerChannel"); }
            set { SetNoteValue(false, "B", "PerChannel", value); }
        }
        public int BCurrent
        {
            get { return GetNoteValue(false, "B", "Current"); }
            set { SetNoteValue(false, "B", "Current", value); }
        }
        #endregion

        #region  A
        public int AChannelStart
        {
            get { return GetNoteValue(false, "A", "ChannelStart"); }
            set { SetNoteValue(false, "A", "ChannelStart", value); }
        }

        public int AChannelEnd
        {
            get { return GetNoteValue(false, "A", "ChannelEnd"); }
            set { SetNoteValue(false, "A", "ChannelEnd", value); }
        }

        public int APerChannel
        {
            get { return GetNoteValue(false, "A", "PerChannel"); }
            set { SetNoteValue(false, "A", "PerChannel", value); }
        }

      

        #endregion
        */
        private int GetCurrent(string key)
        {
            return doc.Root.Descendants("Product").First((p) =>
             {
                 return p.Attribute("ID").Value == key;
             }).Attribute("Current").Value.TryInt();
        }
        private void SetCurrent(string key, int value)
        {
            doc.Root.Descendants("Product").First((p) =>
           {
               return p.Attribute("ID").Value == key;
           }).Attribute("Current").Value = value.ToString();
        }
        public int ACurrent
        {
            get { return GetCurrent("A"); }
            set { SetCurrent("A", value); }
        }

        public int BCurrent
        {
            get { return GetCurrent("B"); }
            set { SetCurrent("B", value); }
        }

        public string Port
        {
            get { return GetPort(); }
            set { SetPort(value); }
        }

        private List<ChannelInfo> GetProductChannels(string key)
        {
            List<ChannelInfo> list = new List<ChannelInfo>();
            var eles = doc.Root.Descendants("Product").First((p) =>
            {
                return p.Attribute("ID").Value == key;
            }).Descendants("Channel");
            foreach (var item in eles)
            {
                ChannelInfo info = new ChannelInfo();
                info.ID = item.Attribute("ID").Value.TryInt();
                info.Count = item.Attribute("Count").Value.TryInt();
                info.IndexS = item.Attribute("IndexS").Value.TryInt();
                info.IndexE = item.Attribute("IndexE").Value.TryInt();
                list.Add(info);
            }
            return list;
        }

        public List<ChannelInfo> GetProductAChannels()
        {
            return GetProductChannels("A");
        }
        public List<ChannelInfo> GetProductBChannels()
        {
            return GetProductChannels("B");
        }

        public void SetProductChannels(List<ChannelInfo> list, string key)
        {
            var index = 0;
            list.ForEach((i) =>
            {
                i.IndexS = index;
                i.IndexE = index + i.Count - 1;
                index += i.Count;
            });

            doc.Root.Descendants("Product").First((px) =>
            {
                return px.Attribute("ID").Value == key;
            }).Descendants("Channel").Remove();

            var p = doc.Root.Descendants("Product").First((px) =>
            {
                return px.Attribute("ID").Value == key;
            });

            foreach (var item in list)
            {
                var Xe = new XElement("Channel");
                Xe.SetAttributeValue("ID", item.ID);
                Xe.SetAttributeValue("Count", item.Count);
                Xe.SetAttributeValue("IndexS", item.IndexS);
                Xe.SetAttributeValue("IndexE", item.IndexE);
                p.Add(Xe);
            }
            Save();
        }

        public void SetProductAChannels(List<ChannelInfo> list)
        {
            SetProductChannels(list, "A");
        }
        public void SetProductBChannels(List<ChannelInfo> list)
        {
            SetProductChannels(list, "B");
        }

    }

    public class ChannelInfo
    {
        public int ID { get; set; }
        public int Count { get; set; }
        public int IndexS { get; set; }
        public int IndexE { get; set; }

    }
}
