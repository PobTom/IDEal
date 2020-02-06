using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ideal
{
    public partial class ProjectEditor : Form
    {
        private TreeView _projectCont;
        private readonly string _googleTextDefault; 

        public TextBox GoogleTextBox => googleTextBox;

        //attributes
        public TabControl tab
        {
            get { return ClassCont; }  //get the tabcontrol of classes
        }


        public ProjectEditor()
        {
            InitializeComponent();
            _googleTextDefault = googleTextBox.Text;
        }
        public ProjectEditor(RichTextBox r)
        {
            InitializeComponent();
            Errortext = r;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            ReadXmlToHelper(Searchtext.Text);
        }

        public static string getRtfKeywordFile(string text)
        {
            var selectedPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                                 "\\Resources\\SearchDesc";

            var directoryInfo = new DirectoryInfo(selectedPath);
            var directory = directoryInfo.GetDirectories();

            if (directory.Length > 0)
            {
                return null;
            }

            foreach (var file in directoryInfo.GetFiles("*.rtf"))
            {
                if (file.Exists)
                {
                    if (file.Name.Substring(0, file.Name.Length - 4) == text)
                    {
                        return file.FullName;
                    }
                }
            }
            return null;
        }

        public void ReadXmlToHelper(string text)
        {
            var file = getRtfKeywordFile(text);
            if (file != null)
            {
                Displayhelptext.LoadFile(file);
            }
            googleTextBox.Text = "java " + text;
        }

        internal void PassForm(TreeView projectCont)
        {
            _projectCont = projectCont;
        }

        public void RemoveTab(TabPage tab)
        {
            ClassCont.Controls.Remove(tab);
        }
        
        private void googleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                // http://www.google.com/search?q=Google+tutorial+create+link
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + googleTextBox.Text);
            }
        }

        private void SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search_Click(this, e);
            }
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            var nodes = ExtractClassNodes(_projectCont.Nodes);
            var dictionary = new Dictionary<string, string>();
            foreach (var nod in nodes)
            {
                //// get the file attributes for file or directory
                //FileAttributes attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());
                dictionary[nod.Text] = nod.Tag.ToString();
            }

            var emailForm = new EmailForm(dictionary);
            emailForm.ShowDialog();
        }

        private List<TreeNode> ExtractClassNodes(TreeNodeCollection initialNodes)
        {
            var extractedClasses = new List<TreeNode>();
            foreach (TreeNode nod in initialNodes)
            {
                var extractedNodes = extractNodes(nod);
                if (extractedNodes.Count() != 0)
                {
                    extractedClasses.AddRange(extractedNodes);
                }
            }
            return extractedClasses;
        }
        private List<TreeNode> extractNodes(TreeNode node)
        {
            var extractedNodes = new List<TreeNode>();
            if (node.Nodes.Count > 0)
            {
                foreach(TreeNode nod in node.Nodes)
                {
                    var tempExtracts = extractNodes(nod);
                    if (tempExtracts.Count != 0)
                    {
                        extractedNodes.AddRange(tempExtracts);
                    }
                }
            } else
            {
                extractedNodes.Add(node);
            }
            return extractedNodes;
        }

        private void emailTutorButton_Click(object sender, EventArgs e)
        {
            var nodes = ExtractClassNodes(_projectCont.Nodes);
            var dictionary = new Dictionary<string, string>();
            foreach (var nod in nodes)
            {
                //// get the file attributes for file or directory
                //FileAttributes attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());
                dictionary[nod.Text] = nod.Tag.ToString();
            }

            var emailForm = new EmailForm(dictionary)
            {
                titleLabel = {Text = "Email your teacher"},
                descLabel = {Text = "Use this form to quickly email your teacher and ask them for help. Just describe your problem and select the files you would like to attach for them to look at."},
                emailLabel = {Text = "Teacher's email:"},
                emailTextBox = {Text = ProjectWindow.currentTutorEmail, Enabled = false}
            };

            emailForm.ShowDialog();
        }

        private void askDuckButton_Click(object sender, EventArgs e)
        {
            var duckForm = new DuckForm(ProjectWindow.duckNodes);
            duckForm.ShowDialog();
        }

       private void gogoleSearchButton_Click(object sender, EventArgs e)
        {
            // http://www.google.com/search?q=Google+tutorial+create+link
            System.Diagnostics.Process.Start("https://www.google.com/search?q=" + googleTextBox.Text);
        }

        private void googleTextBox_Enter(object sender, EventArgs e)
        {
            if (googleTextBox.Text == _googleTextDefault)
                googleTextBox.Text = "";
        }

        private void googleTextBox_Leave(object sender, EventArgs e)
        {
            if (googleTextBox.Text == "")
                googleTextBox.Text = _googleTextDefault;
        }
    }

}
