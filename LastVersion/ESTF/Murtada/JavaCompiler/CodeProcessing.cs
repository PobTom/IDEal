using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace JavaCompilingToolMurtada.BugsDetector
{
    class CodeProcessing : ProjectConfiguration.JDKConfiguration
    {
        public static Process process;

        protected StreamReader strReader;
        protected StreamWriter strWriter;
        private string EXE,JavaPath;


        public CodeProcessing()
        {
            Initialize();
        }

        public CodeProcessing(string EXE)
        {
            // set jdk path
            Initialize();
            //set whether the compiler or runner by setting the path+javac or java
            this.EXE = EXE;
        }

        private void Initialize()
        {
            process = new Process();
            SetJavaDir();          
        }

        public bool RunProcess(string workingDirectory, string fileName)
        {
            var processStarted = false;
            var filePath = string.Format("{0}{1}", JavaPath, EXE);
           
            if (File.Exists(filePath))
            {
                process.StartInfo.FileName = JavaPath+EXE;
                process.StartInfo.Arguments = fileName;
                process.StartInfo.WorkingDirectory = workingDirectory;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
               // MessageBox.Show("11");
                processStarted = process.Start();
               // MessageBox.Show("22");
            }
            else
            {
                MessageBox.Show("Unable to compile java file. Check your Java Path settings: Current Java Path : " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return processStarted;
        }

        private void SetJavaDir()
        {
            if (GetJavaPath() == "")
            {
                MessageBox.Show("The Java path has not been set. Please use the Folder Browser Dialog on the next screen to set the Java path", "TinyJavaEditor - Set Java Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var fBDialog = new FolderBrowserDialog();
                fBDialog.ShowDialog();

                var path = fBDialog.SelectedPath;
                JavaPath = path;
                SetJavaPath(path);
            }
            else
            {
                JavaPath = GetJavaPath();
            }
        }
    }
}
