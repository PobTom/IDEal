using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace JavaCompilingToolMurtada.ProjectConfiguration 
{
    public class JDKConfiguration
    {
        XmlDocument doc = new XmlDocument();

        public JDKConfiguration()
        {
            if (File.Exists("JDKConfiguration.xml"))
            {
                doc.Load("JDKConfiguration.xml");
            }
            else
            {
                string xmlDefault = @"<?xml version=""1.0"" encoding=""utf-8""?>
<app>
    <java></java>
    <projects>
    </projects>
</app>";

                using (StreamWriter cWriter = new StreamWriter("JDKConfiguration.xml"))
                {
                    cWriter.Write(xmlDefault);
                    cWriter.Flush();
                }
                doc.Load("JDKConfiguration.xml");
            }
        }

        public string GetJavaPath()
        {
            XmlNode javaNode = doc.SelectSingleNode("/app/java");
            return javaNode.InnerText;
        }

        public void SetJavaPath(string path)
        {
            XmlNode javaNode = doc.SelectSingleNode("/app/java");
            javaNode.InnerText = path;
            doc.Save("JDKConfiguration.xml");
        }

        public List<string> GetProjects()
        {
            XmlNodeList projectNodeList = doc.SelectNodes("/app/projects/project");

            List<string> list = new List<string>();

            foreach (XmlNode node in projectNodeList)
            {
                list.Add(node.InnerText);
            }

            return list;
        }

        public void AddProject(string project)
        {
            XmlNode appNode = doc.SelectSingleNode("/app");
            XmlNode projectNode = doc.SelectSingleNode("/app/projects");

            if (projectNode == null)
            {
                appNode.InnerXml += "<projects><project>" + project + "</project></projects>";
            }
            else
            {
                projectNode.InnerXml += "<project>" + project + "</project>";
            }
            doc.Save("JDKConfiguration.xml");
        }
    }
}
