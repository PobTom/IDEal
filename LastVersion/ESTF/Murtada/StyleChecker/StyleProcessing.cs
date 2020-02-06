using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaCompilingToolMurtada.StyleChecker
{
    class StyleProcessing : ProjectConfiguration.JDKConfiguration
    {
        
        public static Process process;

        protected StreamReader strReader;
         private string EXE,JavaPath;


        public StyleProcessing()
        {
            initialize();
        }

        public StyleProcessing(string EXE)
        {
            // set jdk path
            initialize();
            //set whether the compiler or runner by setting the path+javac or java
            this.EXE = EXE;
        }

        private void initialize()
        {
            process = new Process();
            SetJavaDir();          
        }

        public bool RunProcess(string WorkingDirectory, string FileName)
        {// this is checkstyle only, no PMD here
            bool processStarted = false;
          //  MessageBox.Show(WorkingDirectory + "\\" + FileName);
               
            if (File.Exists(JavaPath+EXE))
            {
                process.StartInfo.FileName = JavaPath+EXE;
                string currentProgramPath =   getCurrentProgramPath();
                process.StartInfo.Arguments = " -jar " + currentProgramPath + "\\Resources\\tools\\checkstyle-8.20-all.jar -c /google_checks.xml  \"" + WorkingDirectory + "\\" + FileName + "\"";
               // process.StartInfo.Arguments = " -d " + WorkingDirectory + "\\" + FileName + "\"";
                //string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Extra_lessons";// get the current path of Application
                process.StartInfo.WorkingDirectory = JavaPath;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
               process.StartInfo.RedirectStandardInput = true;
              //  MessageBox.Show("33");
                processStarted = process.Start();
                //MessageBox.Show("2332");
            }
            else
            {
                MessageBox.Show("Unable to compile java file. Check your Java Path settings: Current Java Path : " + JavaPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return processStarted;
        }

        private void SetJavaDir()
        {
            if (GetJavaPath() == "")
            {
                MessageBox.Show("The Java path has not been set. Please use the Folder Browser Dialog on the next screen to set the Java path", "TinyJavaEditor - Set Java Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FolderBrowserDialog fBDialog = new FolderBrowserDialog();
                fBDialog.ShowDialog();

                string path = fBDialog.SelectedPath;
                JavaPath = path;
                SetJavaPath(path);
            }
            else
            {
                JavaPath = GetJavaPath();
            }
        }
    private string getCurrentProgramPath()
    {
        string directoryPath = Directory.GetCurrentDirectory();
        DirectoryInfo parent = Directory.GetParent(directoryPath);
        while (parent != null && !"ESTF".Equals(parent.Name))
        {
            parent = Directory.GetParent(parent.FullName);
        }
        return parent.FullName;
    }
    }
}
