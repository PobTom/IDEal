using FastColoredTextBoxNS;
using System;
using System.Windows.Forms;

namespace Ideal
{
    public partial class WorkSpace : Form
    {
        public WorkSpace()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(2000);
        }

        private void Create_new_project_Click(object sender, EventArgs e)
        {
            var create = new CreateProject();
            create.Show();
            
        }
        FastColoredTextBox _texteditor;
        private void Open_new_project_Click(object sender, EventArgs e)
        {
            var editor = new ProjectWindow();

            var open = new OpenNewProject(editor.Treeview, editor.classcontainer, editor.search, editor.displayhelp);
            open.OpnenNewProject();
            if (open.Flag)
            {
                editor.Show();
            }
            else
            {
                MessageBox.Show("Chosen folder is not a valid project", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                open.Dispose();
            }

        }
    }
}
