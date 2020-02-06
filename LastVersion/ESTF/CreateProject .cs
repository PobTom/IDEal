using System;
using System.Windows.Forms;
using System.IO;
namespace Ideal
{
    public partial class CreateProject : Form
    {
        readonly createProject _create = new createProject();
        public TreeView folder;
        public string folderPath;
       // Est est;
       readonly ProjectWindow _est;
        readonly ContextMenuStrip _menu;
        public CreateProject(TreeView folder,ProjectWindow est,ContextMenuStrip menu)
        {
            this.folder = folder;
            _est = est;
            _menu = menu;
            InitializeComponent();
        }
        public CreateProject()
        {
            InitializeComponent();
            var currentDir = /*Path.GetDirectoryName(Directory.GetCurrentDirectory());
            if (string.IsNullOrEmpty(currentDir))
                currentDir =*/ "C:\\Projects";

            folderPath = Path.GetDirectoryName( currentDir+ "\\ESTFProject");
            pathname.Text = folderPath;
        }
       
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (projectName1.Text == string.Empty)
            {
                MessageBox.Show("Project name cannot be empty", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _create.Addfolder(folder, projectName1.Text, folderPath);

                if (_create.creator)
                {
                    if (_est == null)
                    {
                        var main = new ProjectWindow();
                        var tn = _create.ADDNode(folder, projectName1.Text, folderPath, main.menu);
                        main.Treeview.Nodes.Add(tn);
                        main.Treeview.SelectedNode=tn;
                        main.Show();
                    }
                    else
                    {
                        var tn = _create.ADDNode(folder, projectName1.Text, folderPath, _menu);
                        folder.Nodes.Add(tn);
                        folder.SelectedNode = tn;
                    }



                    Close();
                }
            }
        }
       
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            
            var directchoosedlg = new FolderBrowserDialog();
            directchoosedlg.SelectedPath = @"C:\Projects\ESTFProject";
            if (directchoosedlg.ShowDialog() == DialogResult.OK)
            {
                folderPath = directchoosedlg.SelectedPath;
            }
            
            pathname.Text = folderPath;
        }
    }
}
