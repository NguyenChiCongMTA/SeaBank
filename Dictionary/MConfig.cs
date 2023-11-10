using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Reflection;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    public class MConfig : MBase
    {
        public string ReadSetting(string key)
        {
            return "";
        }
        public void WriteSetting(string key, string value)
        {
            XmlDocument doc = loadConfigDocument();
            XmlNode node = doc.SelectSingleNode("//appSettings");
            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");
            try
            {
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                if (elem != null)
                    elem.SetAttribute("value", value);
                else
                {
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(getConfigFilePath());
            }
            catch { throw; }
        }
        public void RemoveSetting(string key)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();
            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");
            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    doc.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e) { throw new Exception(string.Format("The key {0} does not exist.", key), e); }
        }

        private XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e) { throw new Exception("No configuration file found.", e); }
        }

        private string getConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }
        public void ConfigStringConnectApp(string key, string value, string section)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection(section);
        }
    }

}
