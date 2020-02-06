using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace JavaCompilingToolMurtada.PMD
{
    class ImplementPMD
    {
        private string _pmDpath;
        private Process _process;

        public ImplementPMD() 
        {
            _process = new Process();
            _pmDpath = getCurrentProgramPath() + "\\Resources\\pmd";
            _pmDpath = getCurrentProgramPath() + "\\Resources\\pmd2";
            // this.PMDpath = getCurrentProgramPath() + "\\Resources\\pmd\\pmd - master\\pmd - java\\src\\main";
            //this.PMDpath = getCurrentProgramPath() + "\\Resources\\pmd\\pmd - master\\pmd - java\\src\\main\\resources\\rulesets\\java";

           // this.Ruleset = Directory.GetCurrentDirectory() + "\\PMD\\java";
           // this.Ruleset = Directory.GetCurrentDirectory() + "\\PMD\\java";
            // MessageBox.Show();
        }

        public string RunPMD(string workingDirectory, string FileName)
        {
        //    bool processStarted = false;

        //    if (File.Exists(PMDpath + "\\pmd.bat"))
        //    {
        //        process.StartInfo.FileName = PMDpath + "\\pmd.bat";
        //        process.StartInfo.Arguments = " -d " + WorkingDirectory + FileName + " -f  xml -R " + WorkingDirectory + "\\unusedcode.xml";
        //        process.StartInfo.WorkingDirectory = PMDpath;
        //        process.StartInfo.CreateNoWindow = true;
        //        process.StartInfo.ErrorDialog = true;
        //        process.StartInfo.UseShellExecute = false;

        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.StartInfo.RedirectStandardError = true;
        //        process.StartInfo.RedirectStandardInput = true;
        //        // MessageBox.Show("11");
        //        processStarted = process.Start();
        //        // MessageBox.Show("22");
        //        StreamReader strReader = process.StandardOutput;
        //        string response = strReader.ReadToEnd();
        //        MessageBox.Show(response);
        //        MessageBox.Show(process.StartInfo.FileName + "***\n" + process.StartInfo.Arguments + "***\n" + process.StandardError.ReadToEnd());
        //        MessageBox.Show("11");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Unable to compile java file. Check your Java Path settings: Current Java Path : " + PMDpath);
        //    }
        //    return processStarted;
        //}
        var ruleset = "";
        var fileEntries = Directory.GetFiles(_pmDpath + "\\rules");
            foreach (var fileName in fileEntries)
            {
                ruleset += "\"" + fileName + "\"" + ",";
            }
            ruleset = ruleset.Substring(0, ruleset.Length - 1);
            if (File.Exists(_pmDpath + "\\bin\\pmd.bat"))
            {
                _process.StartInfo.FileName = _pmDpath + "\\bin\\pmd.bat";
                _process.StartInfo.Arguments = " -d \"" + workingDirectory +"\\"+ FileName + "\" -f  xml  -R " + ruleset;

              //  MessageBox.Show("Before response: Current process.StartInfo.Arguments : " + process.StartInfo.Arguments);
              _process.StartInfo.WorkingDirectory = workingDirectory;
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.ErrorDialog = true;
                _process.StartInfo.UseShellExecute = false;

                _process.StartInfo.RedirectStandardOutput = true;
                _process.StartInfo.RedirectStandardError = true;
                _process.StartInfo.RedirectStandardInput = true;
                // MessageBox.Show("11");
                _process.Start();
                // MessageBox.Show("22");
                StreamReader strReader = _process.StandardOutput;
                var response = strReader.ReadToEnd();
              //  MessageBox.Show(response);
              using (var cWriter = new StreamWriter("CodeAnalysisResult.xml"))
                {
                    var startIndex = response.IndexOf("<?");
                    if (startIndex != -1)
                    {
                        response = response.Substring(startIndex);
                    }
                    //  response = response.Substring(2);
                    cWriter.Write(response);
                    cWriter.Flush();
                }
                // MessageBox.Show(process.StartInfo.FileName + "***\n" + process.StartInfo.Arguments + "***\n" + process.StandardError.ReadToEnd());
                //   MessageBox.Show("11");
                /* AnalysisXML aa = new AnalysisXML(response);
                 MessageBox.Show(aa.GetResult());
                */

              //  MessageBox.Show("Before response: Current PMD Path : " + PMDpath);
                return response;
            }

            MessageBox.Show("Unable to implement PMD for the java file. Check your Java Path settings: Current PMD Path : " + _pmDpath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "";
        }
        private string getCurrentProgramPath()
        {
            var directoryPath = Directory.GetCurrentDirectory();
            int index;
            var dirName = "ESTF";

            try
            {
                index = directoryPath.IndexOf(dirName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return directoryPath.Substring(0, index+dirName.Length+1);

            //return directoryPath+@"\";
            //var parent = Directory.GetParent(directoryPath);

            /*MessageBox.Show(parent.FullName);
            if (parent !=null && parent.Name != "ESTF")
            {
                parent = Directory.GetParent(parent.FullName);
            }
            return parent.FullName;*/
        }
    }
}
