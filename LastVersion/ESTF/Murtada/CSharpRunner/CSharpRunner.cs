using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaCompilingToolMurtada.CSharpRunner
{
    class CSharpRunner
    {
        public string code { get; set; }

        public CSharpRunner(string filestring)
        {
            code = filestring;
            if (code != "")
            {
                try
                {
                  //  Compile(code);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No code to compile.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public string Compile(string code)
        {
            var response = "";
            string path;
            string p2;
            p2 = "test";
            path = p2 + ".cs";
            File.WriteAllText(path, code);

            var process = new Process();
            process.StartInfo.FileName = "compiler/csc.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = path;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            string str1 = process.StandardOutput.ReadToEnd();
           // MessageBox.Show(str1);
        process.WaitForExit();
        var str2 = str1;
            var separator = new string[1]
                {
                    Environment.NewLine
                };
             var num1 = 1;
             var list = str2.Split(separator, (StringSplitOptions) num1).ToList();
             foreach (string text1 in list)
            {
                if (text1.Contains("error") || text1.Contains("fatal"))
                {
                    var num2 = (int)MessageBox.Show(text1, "Compiler Error12354", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                }
            }
            path = path.Replace(".cs", ".exe"); 
              //process.Close();
                try
            {
              // Process.Start(path);
           Process p = new Process();
                p.StartInfo.FileName = path;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.ErrorDialog = false;
                 p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
           
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                StreamReader strReader;
          StreamWriter strWriter;
        

                strReader = p.StandardOutput;

                    //    tstForm.Outputtxtbx.Text = response;
                strWriter = p.StandardInput;

                while (!(p.StandardOutput.EndOfStream))
                {
                    string l = p.StandardOutput.ReadLine();
                    
                        response += l + "\r\n";
                        
                    }
                  

                
              //  MessageBox.Show( response);
            }
            catch (Exception)
            {

            }
                return response;
        }
    }
}