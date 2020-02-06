using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaCompilingToolMurtada.BugsDetector
{
    class ErrorDetector
    {
        private string []Error;
        private string[,] Result;
        private string FileName;

        public ErrorDetector(string err)
        {

            this.Error = err.Split('\n');
            if(Error.Length%3==0)
                Result=new string[Error.Length/3,3];
            else 
                Result=new string[Error.Length,3];
        }

        public ErrorDetector(string err,string filename) 
        {
            this.FileName = filename;
            this.Error = generateErrors(err, filename);
            Result = new string[this.Error.Length, 3];
            //for (int i = 0; i < Error.Length; i++)
            //    if (Error[i].Length == 0) continue;
            //else Error[i] = FileName + ':' + Error[i];
            extraction();
        }
        private string[] generateErrors(string err, string filename)
        {
            List<string> extractedStrings = new List<string>();
            var parts = Regex.Split(err, @"(?=" + filename + ")");
            foreach(string possiblePart in parts)
            {
                var temp = possiblePart.Contains(filename + ":");
                if (possiblePart.Contains(filename + ":"))
                {
                    extractedStrings.Add(possiblePart);
                }
                //
            }
            // string tempString = err.Substring(;
            //tempString.IndexOf(FileName + ":");
            return extractedStrings.ToArray();
            //return err.Split(new string[] { FileName + ':' }, StringSplitOptions.None);
            //throw new NotImplementedException();
        }

        private void extraction() {
            if(Error.Length<=0)
                return;
            int count=0;
            for (int i = 0 ; i < Error.Length; i ++)
            {
                //MessageBox.Show("111:: " + Error[i]);

                string []lines=Error[i].Split('\n');
                for (int j = 0; j < lines.Length; j++)
                {
                   // MessageBox.Show("filw:: " + lines[j]);
                    lines[j] = lines[j].Replace("\r", "");
                    if (lines[j].Contains(FileName+':'))
                    {
                        //extract the number of  line

                        lines[j] = lines[j].Substring((FileName + ':').Length, lines[j].Length - (FileName + ':').Length);
                        Result[count, 0] = lines[j].Substring(0, lines[j].IndexOf(":"));
                        //extract the reason
                        Result[count, 2] = lines[j].Substring(0, lines[j].Length);
                    }
                    if (lines[j].Contains("^"))
                    {
                         //extract the column
                        Result[count++, 1] = lines[j].IndexOf("^")+"";
                    }
                }
            }
        }
        public string[,] GetResult() 
        {
            return Result;
        }
        private void extractLineNumber()
        {

            for (int i = 0,j=0; i < Error.Length; i += 3,j++)
            {
                var ErrorRow=(from t in Error[i] where char.IsDigit(t) select t).ToArray();
                Result[j,0] = new string(ErrorRow);
            }
        }
        private void ExtractErrorColumn()
        {
            for (int i = 2, j = 0; i < Error.Length; i += 3, j++)
            {
                Result[j, 1] = Error[i].IndexOf('^') + "";
            }
        }

    }
}
