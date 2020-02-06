using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace JavaCompilingToolMurtada.StyleChecker
{
    class ImplementStyleChecker:StyleChecker.StyleProcessing
    {
        private string file;
        public ImplementStyleChecker(string file)
            : base("\\bin\\java.exe")
        {
            this.file = file;
        }

        public string StyleJavaCodeFeedback()
        {
         //   MessageBox.Show("start Style processing");
                       
         string response = "";
            if (RunProcess(Path.GetDirectoryName(file), Path.GetFileName(file)))
            {
                strReader = process.StandardOutput;
                response=strReader.ReadToEnd();               
            }
 
          //  MessageBox.Show("#end compiling :"+response);
                       
            return response;
        }
        
    }
}
