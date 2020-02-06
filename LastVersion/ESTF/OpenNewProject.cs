using System.IO;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Ideal
{
    class OpenNewProject:Form
    {
        ProjectEditor _childForm = new ProjectEditor();
        string _project;
        readonly TreeView _treeView;
        readonly FastColoredTextBox _texteditor;
        readonly TabControl _tab;
        readonly TextBox _text1;
        readonly RichTextBox _display;
        public bool Flag;

        public OpenNewProject(TreeView tree, TabControl tab, FastColoredTextBox texte, TextBox text, RichTextBox rich)
        {   
            _treeView = tree;
            _tab = tab;
            _texteditor = new FastColoredTextBox();
            _texteditor= texte;
            _text1 = text;
            _display = rich;
        }
        public OpenNewProject(TreeView tree, TabControl tab,TextBox text,RichTextBox rich)
        {   
            _treeView = tree;
            _tab = tab;
            _text1 = text;
            _display = rich;
        }
       
        public void OpnenNewProject()
        {
            var est = new ProjectWindow();
            var create = new CreateClassForm(_text1,_display);
            var currentDir = /*Path.GetDirectoryName(Directory.GetCurrentDirectory());
            if (string.IsNullOrEmpty(currentDir))
                currentDir =*/ "C:\\Projects";

            var folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = Path.GetDirectoryName(currentDir) +
                               "\\ESTFProject"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _project = folderBrowserDialog.SelectedPath;
                var directoryInfo = new DirectoryInfo(_project);
                var directory = directoryInfo.GetDirectories();
                     
                if (directory.Length > 0)
                {
                    Flag = false;
                    return;
                }

                var node = _treeView.Nodes.Add(directoryInfo.Name);
                _treeView.SelectedNode = node;
                node.Text = directoryInfo.Name;
                node.Tag = directoryInfo.FullName;
                node.ImageIndex = 0;
                foreach (var file in directoryInfo.GetFiles("*.java"))
                {
                    if (file.Exists)
                    {
                        var file1 = _treeView.Nodes[node.Index].Nodes.Add(file.Name);
                        file1.Text = file.Name;
                        file1.Tag = file.FullName;
                        file1.ImageIndex = 1;
                        file1.SelectedImageIndex = 1;
                        //texteditor = new FastColoredTextBox();

                        var texteditor1 = new FastColoredTextBox();
                        //if (texteditor != null)
                        //    texteditor1 = texteditor;
                        texteditor1.PaintLine += est.fastColoredTextBox1_PaintLine;
                        texteditor1.TextChangedDelayed += est.fastColoredTextBox1_TextChangedDelayed;
                                
                        var text = File.ReadAllText(file.FullName);
                        create.OpenClass(file.Name, _tab, texteditor1, directoryInfo.Name, text, file.FullName);
                               
                    }

                }
                _treeView.SelectedNode = node;
                node.Text = directoryInfo.Name;
                node.Tag = directoryInfo.FullName;
                node.ImageIndex = 0;
               
                Flag = true;
            }
            else
                Flag = false;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenNewProject));
            SuspendLayout();
            // 
            // OpenNewProject
            // 
            BackColor = System.Drawing.Color.LightSkyBlue;
            ClientSize = new System.Drawing.Size(288, 261);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            Name = "OpenNewProject";
            ResumeLayout(false);

        }
    }
}
