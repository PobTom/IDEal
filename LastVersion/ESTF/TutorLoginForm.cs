using System;
using System.Windows.Forms;

namespace Ideal
{
    public partial class TutorLoginForm : Form
    {
        public TutorLoginForm()
        {
            InitializeComponent();
        }
        
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (VerifyForm())
            {
                SaveCredentials();
            }
        }

        private void SaveCredentials()
        {
            ProjectWindow.currentTutorName = nameTextBox.Text;
            ProjectWindow.currentTutorEmail = emailTextBox.Text;
            Close();
        }

        private bool VerifyForm()
        {
            const string caption = "Error";
            if (nameTextBox.Text.Length == 0)
            {
                const string message = "Please give us a name :)";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }
            if (!ProjectWindow.isEmailVaild(emailTextBox.Text))
            {
                const string message = "Not a correct email";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ProjectWindow.abortConfig = true;
            Close();
        }

        private void emailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (VerifyForm())
                {
                    SaveCredentials();
                }
            }
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (VerifyForm())
                {
                    SaveCredentials();
                }
            }
        }
    }
}
