using System;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace JavaCompilingToolMurtada.BugsDetector
{
    class Running: CodeProcessing 
    {
        System.Timers.Timer timer; 
      //  TestingForm tstForm;
        public Running( )
            : base(@"\bin\java.exe")
        {
            timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += OnTimedEvent;
        }

       
        public string RunJavaProject(string file)
        {
          string response = ""; 
            if (this.RunProcess( Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)))
            {
                strReader = process.StandardOutput; 
                
            //    tstForm.Outputtxtbx.Text = response;
                strWriter = process.StandardInput;
              //  MessageBox.Show("qqqqqqqq");
                timer.Enabled = true;     
                //process.OutputDataReceived += new DataReceivedEventHandler(tee);
                //process.ErrorDataReceived += new DataReceivedEventHandler(tee);
                while (!(process.StandardOutput.EndOfStream ))
                {
                    //if (process.StandardInput.BaseStream.CanWrite)
                    //{
                    //   process.Suspend();
                    //   configureOutputCompForInput();
                    //   break;                        
                    // //MessageBox.Show("32222222");
                    //} 
                    //////////
                    //foreach (ProcessThread thread in process.Threads)
                    //    if (thread.ThreadState == ThreadState.Wait
                    //        && thread.WaitReason == ThreadWaitReason.UserRequest)
                    //    {
                    //        MessageBox.Show("32222222");
                    //        process.Suspend();
                    //        configureOutputCompForInput();
                    //        break;
                    //        //MessageBox.Show("32222222");
                    //    } 
                    //            ProcessThread th = process.Threads;
                    //            if (th.ThreadState == ThreadState.Wait
                    //&& th.WaitReason == ThreadWaitReason.UserRequest)
                    string l = process.StandardOutput.ReadLine();
                    //if (l.Contains("sd"))
                    //{
                    //    process.Suspend();
                    //    MessageBox.Show("suspend");
                    //    break;
                    //}
                 response += l + "\r\n";
                   // MessageBox.Show("AAA\n" + response.Length + "\n" + response);
                  
               //   tstForm.Outputtxtbx.Text=response;          
                }
                 //if (l.Contains("sd"))
                //{
                //    process.Suspend();
                //    MessageBox.Show("suspend");
                //    break;
                //}
                //response += process.StandardOutput.ReadLine() + "\r\n";
                //MessageBox.Show("AAA\n" + response.Length + "\n" + response);

                //tstForm.Outputtxtbx.Text = response;          
             
                //MessageBox.Show("Process:  "+process.HasExited);
                       
            }
            return response;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           //  MessageBox.Show("32222222");
            //if(process.StandardInput.BaseStream.CanWrite)
          //  process.Suspend();
        }
        private void tee(object sender, DataReceivedEventArgs e)
        {
          
            //throw new NotImplementedException();
        }
        private void configureOutputCompForInput()
        {
           // tstForm.Outputtxtbx.ReadOnly = false;
           // tstForm.Outputtxtbx.Text+=(":");
           // tstForm.Outputtxtbx.Focus();

        }      
    }
}
