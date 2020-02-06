using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ideal.Murtada.PMD
{
    class AnalysisXML
    {
        string Result="";
        XElement xmlDoc;
        public AnalysisXML(string xml) 
        {
       //     xml=xml.Substring(xml.IndexOf("<?")-2);
            xmlDoc = XElement.Load("CodeAnalysisResult.xml");
           
           // xmlDoc.Load(xml);
        }

       public string GetResult() 
        {
          //  XElement root = XElement.Load(file);
            var list = xmlDoc.Descendants("file")
                .SelectMany(report =>
                {
                    var sub = new List<string>();
                    sub.Add(report.Descendants("violation").First().Value);
                    
                    return sub;
                })
                .ToList();
            MessageBox.Show(list.Count+"", "XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach(var s in list)
                Result+=s+"\r\n";
            return Result;
        }
    }
}
