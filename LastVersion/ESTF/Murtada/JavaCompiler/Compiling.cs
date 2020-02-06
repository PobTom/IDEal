using System.IO;

namespace JavaCompilingToolMurtada.BugsDetector
{
    class Compiling: CodeProcessing
    {
        private string file;
        public Compiling(string file)
            : base(@"\bin\javac.exe")
            //: base("/bin/javac.exe")
        {
            this.file = file;
        }

        public string CompilingJavaCode()
        {
            //MessageBox.Show("start compiling");
                       
         var response = "";
            if (RunProcess(Path.GetDirectoryName(file), Path.GetFileName(file)))
            {
                strReader = process.StandardError;
                response=strReader.ReadToEnd();               
            }
            if (response == "")
            {
              /*  UsePMD();
                StyleChecker.ImplementStyleChecker Style = new StyleChecker.ImplementStyleChecker(file);
                string ss = Style.StyleJavaCodeFeedback();
                MessageBox.Show("Style:: " + ss);
           */ }

            //  MessageBox.Show("#end compiling :"+response);
                       
            return response;
        }

    }
}
