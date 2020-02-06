using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace Ideal
{
    public partial class EmailForm : Form
    {
        readonly Dictionary<string, string> _classes;
        public EmailForm(Dictionary<string,string> classes)
        {
            InitializeComponent();
            // foreach(string clazz in classes){
            classCheckedListBox.Items.Clear();
            _classes = classes;
            foreach (var key in classes.Keys)
            {
                classCheckedListBox.Items.Add(key);
            }
        }
        
        private void emailSendButton_Click(object sender, EventArgs e)
        {
            if (VerifyEmailForm())
            {
                SendEmail();
            }
        }

        private bool VerifyEmailForm()
        {
            const string caption = "Error";
            if (subjectTextBox.Text.Length == 0)
            {
                const string message = "Title shouldn't be empty";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            if (!emailTextBox.Text.Contains("@") || //
            !emailTextBox.Text.Contains("."))
            {
              
                const string message = "Not a correct email";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            if (messageTextBox.Text.Length == 0)
            {
                const string message = "Please provide a message";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SendEmail()
        {
            var client = new SmtpClient("in-v3.mailjet.com", 25)
            {
                Credentials = new System.Net.NetworkCredential("43dc58d65cc7930a911b83cdc6f9df32", "27138c7ebc6f28a12a310fcdd26005c7"),
                EnableSsl = true
            };
            var msg = new MailMessage {From = new MailAddress("email@ideal-code.com") };
           // MailMessage msg = new MailMessage {From = new MailAddress(ProjectWindow.currentUserEmail)};
            msg.To.Add(emailTextBox.Text);
            msg.CC.Add(ProjectWindow.currentUserEmail);
            msg.Subject = subjectTextBox.Text;
            msg.Body=messageTextBox.Text;
            foreach(string fileName in classCheckedListBox.CheckedItems)
            {
                msg.Attachments.Add(new Attachment(_classes[fileName]));
            }
            client.Send(msg);

            foreach (var attach in msg.Attachments)
            {
                attach.Dispose();
            }
            Console.WriteLine("Sent");
            Console.ReadLine();
            const string message = "Message Sent :)";
            const string caption = "Message Status";
            MessageBox.Show(message, caption,
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
