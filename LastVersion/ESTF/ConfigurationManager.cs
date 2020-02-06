using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Ideal
{
        public class ConfigurationManager
        {
        string filename = null;
            XmlDocument doc = new XmlDocument();

            public ConfigurationManager(string filename,string[] nodes)
            {
                this.filename = filename;
                if (File.Exists(filename))
                {
                    doc.Load(filename);
                }
                else
                {
                string xmlDefault = @"<?xml version=""1.0"" encoding=""utf-8""?>
<config>";
                foreach(string node in nodes){
                    xmlDefault += "<" + node + "></" + node + @">
";
                }
                xmlDefault+=@"
</config>";

                    using (StreamWriter cWriter = new StreamWriter(filename))
                    {
                        cWriter.Write(xmlDefault);
                        cWriter.Flush();
                    }
                    doc.Load(filename);
                }
            }

            public string getNode(string node)
            {
                XmlNode xmlNode = doc.SelectSingleNode("/config/"+node);
                return xmlNode.InnerText;
            }

            public string[] getNodes()
            {
            XmlNodeList xmlNodes = doc.SelectNodes("/config/*");
            string[] stringNodes = new string[xmlNodes.Count];
            for(int i=0; i < stringNodes.Length; i++)
            {
                stringNodes[i] = xmlNodes.Item(i).InnerText;
            }
            return stringNodes;
            }

            public void setNode(string node, string value)
            {
                XmlNode javaNode = doc.SelectSingleNode("/config/"+node);
                javaNode.InnerText = value;
            }

            public void save()
            {
                doc.Save(filename);
            }

            
        }
}
