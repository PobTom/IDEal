using System;
using System.Windows.Forms;

namespace Ideal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
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
            ProjectWindow.currentUserName = nameTextBox.Text;
            ProjectWindow.currentUserEmail = emailTextBox.Text;
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
                    MessageBoxIcon.Warning);
                return false;
            }
            if (!ProjectWindow.isEmailVaild(emailTextBox.Text))
            {
                const string message = "Not a correct email";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ProjectWindow.abortConfig = true;
                        Close();
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
    }
}
