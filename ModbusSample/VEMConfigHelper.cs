using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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

        public void SetNoteValue(bool defaultnote, string p, string key,object value)
        {
            doc.Root.Element(defaultnote ? "Default" : "Instance").Elements("Product").FirstOrDefault((n) =>
            {
                return n.Attribute("ID").Value == p;
            }).Element(key).SetValue(value);
        }

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

        public int ACurrent
        {
            get { return GetNoteValue(false, "A", "Current"); }
            set { SetNoteValue(false, "A", "Current", value); }
        }

        #endregion


    }
}
