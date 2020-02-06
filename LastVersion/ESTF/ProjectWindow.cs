using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using JavaCompilingToolMurtada.BugsDetector;
using JavaCompilingToolMurtada.PMD;
using System.Xml;

namespace Ideal
{
    public partial class ProjectWindow : Form
    {
        /// <summary>
        /// get the constructor of other classes
        /// </summary>
        public static string currentUserName = null;
        public static string currentUserEmail = null;
        public static string currentTutorName = null;
        public static string currentTutorEmail = null;
        public static bool abortConfig = false;
        private FastColoredTextBox _textEditor = new FastColoredTextBox();
        readonly createProject _create = new createProject();
        readonly ProjectEditor _fochild = new ProjectEditor();
        public TextBox search;
        public RichTextBox displayhelp;
        public RichTextBox feedback;
        private TreeNode _lastNode;

        public static bool isEmailVaild(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        //make private attributes public
        public TreeView Treeview
        {
            get { return ProjectCont; }  // make treeview local
            set { ProjectCont = Treeview; }
        }
        public ContextMenuStrip menu
        {
            get { return ClassControl; }
            set { ClassControl = menu; }

        }
       public  TabControl classcontainer ;
        string _classpath, _claasselected;



        public ProjectWindow()
        {
            InitializeComponent();
            _fochild.MdiParent = this;
            _fochild.WindowState = FormWindowState.Maximized;
            _fochild.BringToFront();
            _fochild.Show();
            classcontainer = _fochild.tab;// get the class container tabcontrol 
            search = _fochild.Searchtext;
            displayhelp = _fochild.Displayhelptext;
            feedback = _fochild.Errortext;
            // texteditor = geteditor();        
            _fochild.PassForm(ProjectCont);
        }

        public ProjectWindow(TreeView t)
        {
            InitializeComponent();
            ProjectCont = t;
        }
        /// <summary>
        /// create method to populate the listview with the extra class lessons
        /// </summary>
        /// <param name="lsv"></param>
        /// <param name="folder"></param>
        /// <param name="fileType"></param>
         private void PopulateListBox(ListView lsv, string folder, string fileType)
         {
             var directoryInfo = new DirectoryInfo(folder);
             var files = directoryInfo.GetFiles(fileType);
             foreach (var file in files)
             {
                 var filepath = Path.Combine(folder, file.Name);
                 var filename = Path.GetFileNameWithoutExtension(filepath);
                 var classes = new ListViewItem();
                 lsv.SmallImageList = imageList1Project;
                 classes.Text = filename;
                 classes.Tag = filepath;
                 classes.ImageIndex = 1;
                 lsv.Items.Add(classes);
             }
         }
         
         public Progressform SaveAll()
         {
             double sum = 0;
             var i = classcontainer.Controls.Count;
             for (var r = 0; r < i; r++)
             {
                 foreach (Control texteditor in classcontainer.TabPages[r].Controls)
                 {
                     if (texteditor.GetType() == typeof(FastColoredTextBox))
                     {
                         var textEditor = (FastColoredTextBox)texteditor;
                         sum += texteditor.Text.Length;
                         Writefile(textEditor, textEditor.Tag.ToString());                       
                     }
                 }
             }

             var p = new Progressform("Saving Progress", sum);
             //p.Show();
            p.ShowDialog();
            return p;
         }

         private void Save_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            if (_textEditor == null)
            {
                Save_as_Click(sender, e);
            } else
            {
                SaveFile(_textEditor, _textEditor.Tag.ToString());
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        //create class in add method
        private void addClassToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            AddClass();
        }


        public void AddClass()
        {
            AddClass(false);
        }
        public void AddClass(bool topMost)
        {
            ProjectCont.GetNodeCount(true);
            var node = GetNode();

                // get the file attributes for file or directory
                var attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                _textEditor = new FastColoredTextBox();
                _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                classcontainer.MouseClick += ClassCont_MouseClick;
                var addClass = new CreateClassForm((string)node.Tag, node, classcontainer, _fochild.Searchtext, _fochild.Displayhelptext, _textEditor, envoroment_icon, feedback);
                if (topMost) { 
                    addClass.TopMost = true;
                }
                addClass.Show();
            }
            else
            {
                MessageBox.Show("This is a class not project, please select Project to add class", "Select project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private TreeNode GetNode()
        {
           var node = ProjectCont.SelectedNode;
            if (node == null)
            {
                return _lastNode;
            }

            if (node.Nodes.Count != 0 | node.Parent == null)
            {
                node = ProjectCont.SelectedNode;
            } else {
                if (node.Nodes.Count == 0)
                {
                    node = node.Parent;
                }
            }
            _lastNode = node;
            return node;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var create = new CreateProject(ProjectCont, this, ClassControl);
            create.Show();
        }
        // method open the selected tab by clicking on the node class
       
        public void OpenTabPage(string Path, TabControl tabControl1,TreeNode node)
        {
            bool flag = true;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (Path.Equals(tab.Tag.ToString()))
                {
                    tabControl1.SelectedTab = tab;
                    _textEditor = GetEditor();
                    tabControl1.SelectTab(tab);
                    flag = false;
                }
            }

            if (flag)
            {
                _textEditor = new FastColoredTextBox {Tag = node.Tag};
                var addingTab = new CreateClassForm();
                if (!File.GetAttributes(node.Tag.ToString()).HasFlag(FileAttributes.Directory))
                {                
                    var text = System.IO.File.ReadAllText(node.Tag.ToString());

                    _textEditor = addingTab.AddTextEditor(_textEditor, node.Text, node.Parent.Text, text);
                    _textEditor.TextChangedDelayed += fastColoredTextBox1_TextChangedDelayed;
                    _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                    classcontainer.MouseClick += ClassCont_MouseClick;
                    addingTab.AddTabPage(node.Text, classcontainer, _textEditor);
                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        if (node.Tag.Equals(tab.Tag.ToString()))
                        {
                            tabControl1.SelectTab(tab);
                            break;
                        }
                    }
                }
            }
        }

        public string Getextension(FastColoredTextBox texteditor)
        {
                var getextension = Path.GetExtension(texteditor.Tag.ToString());

                return getextension == ".java" ? "Java" : "C#";
        }

        private void ProjectCont_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenTabPage(SubNodeTag(), classcontainer, SubNode());
            
        }
        public TreeNode SubNode()
        {
           return ProjectCont.SelectedNode;
        }
        public string SubNodeTag()
        {
            return ProjectCont.SelectedNode.Tag.ToString();
        }
        // add extra lessons to class calls
        private void addToProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = new FastColoredTextBox();
            _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
            _textEditor.TextChangedDelayed += fastColoredTextBox1_TextChangedDelayed;
            classcontainer.MouseClick += ClassCont_MouseClick;
        }
        // make the right click of object shows the menue
       
        public void RemoveText(object sender, EventArgs e)
                    {
                       _fochild.Searchtext.Text = "";
                     }

                public void AddText(object sender, EventArgs e)
                  {
                  if(string.IsNullOrWhiteSpace(_fochild.Searchtext.Text))
                           _fochild.Searchtext.Text = "Search here...";
                  }

        /// <summary>
        /// methods of saving files /class
        /// </summary>
        /// <param name="texteditor"></param>
        public void saveAs_file(FastColoredTextBox texteditor)
        {
            var saveResult = saveFileDialog1.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;
                Writefile(texteditor, path);               
                var p = new Progressform("Saving Progress", texteditor.Text.Length);
                p.Show();
            }
        }

        public void SaveFile(FastColoredTextBox text, string Path)
        {
            if (Path == string.Empty)
            {
                var saveResult = saveFileDialog1.ShowDialog();
                if (saveResult == DialogResult.OK)
                {
                    var path = saveFileDialog1.FileName;
                    Writefile(text, path);
                    //    Progressform p = new Progressform("Saving Progress", text.Text.Length);
                    //    p.Show();
                }
            }
            else
            {
                Writefile(text, Path);
                var p = new Progressform("Saving Progress", text.Text.Length);
                p.Show();
            }

        }
        public void SaveFile_realTime(FastColoredTextBox text, string Path)
        {
            if (Path == string.Empty)
            {
                var saveResult = saveFileDialog1.ShowDialog();
                if (saveResult == DialogResult.OK)
                {
                    var path = saveFileDialog1.FileName;
                    Writefile(text, path);
                    //    Progressform p = new Progressform("Saving Progress", text.Text.Length);
                    //    p.Show();
                }

            }
            else
            {
                Writefile(text, Path);
            }
        }

        public void Writefile(FastColoredTextBox texteditor, string path)
        {
            try
            {
                var sw = new StreamWriter(path);
                sw.Write(texteditor.Text);
                sw.Close();
            }
            catch (IOException ioe)
            {
                MessageBox.Show("Error occured :" + ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void Save_as_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            saveAs_file(_textEditor);
        }

        private void Save_All_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void solutionExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Removefromsolution();
        }
        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFromcomputer();
        }
        public double Getlength(string path)
        { double sum=0;
        var myDir = new DirectoryInfo(path);

        foreach (var file in myDir.GetFiles("*.java"))
        {
            if (file.Exists)
            {
                double count = file.Length;
                sum += count;
                
            }
        }
        return sum;
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            _textEditor.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            _textEditor.Redo();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _textEditor =GetEditor();
            //MessageBox.Show(_textEditor.Text.Length.ToString());
        }

        private void Run_Click(object sender, EventArgs e)
        {
            SaveAll();
      //      var createClassForm = new CreateClassForm();
            _textEditor = GetEditor();
            run(_textEditor.Tag.ToString());
            if (_fochild.Errortext.Text.Length > 0)
            {
                _fochild.Error.SelectedIndex = 2;
            }
            /*Classcreator cre = new Classcreator();
                  texteditor = geteditor();
                  MessageBox.Show(texteditor.Tag.ToString());
                  SetLines(new int[]{0,7,3});
                  texteditor.PaintLine += new EventHandler<PaintLineEventArgs>(fastColoredTextBox1_PaintLine);
                  feedback.Text = "line fdfdfvv 8fvf8d8 fd";
                  MessageBox.Show(getextension(texteditor));//type of file
            
                  */
        }
        int[] _line = { -1};
      
        public void SetLines(int[] line) { this._line = line; }
        string[] _error = { "hello", "talked", "like" };
        public void fastColoredTextBox1_PaintLine(object sender, PaintLineEventArgs e)
        {
            var i = 0;
            while (i < _line.Length)
            {
                if (e.LineIndex == _line[i])
                {
                    Brush brush;
                    Point[] points = new Point[3];
                    points[0] = new Point(0, e.LineRect.Top);
                    points[1] = new Point(15, e.LineRect.Top+7);
                    points[2] = new Point(0, e.LineRect.Top+15);
                    using (brush = new SolidBrush(Color.Red))
                    {
                        e.Graphics.FillPolygon(brush, points);
                    }
                    //using (brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.LightPink, Color.Red, 45))
                    //      e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);

                    
                    //points[1] = new Point(0, e.LineRect.Top);
                    //points[2] = new Point(e.LineRect.Top, e.LineRect.Top);
                    //e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 45);
                }

                i++;
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            classcontainer.MouseClick += ClassCont_MouseClick;
            var open = new OpenNewProject(ProjectCont, classcontainer,_textEditor,search,displayhelp);
            open.OpnenNewProject();
        }

        private void helloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var create = new CreateProject(ProjectCont, this, ClassControl);
            create.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = new FastColoredTextBox();
            _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
            _textEditor.TextChangedDelayed += fastColoredTextBox1_TextChangedDelayed;
            classcontainer.MouseClick += ClassCont_MouseClick;
            var open = new OpenNewProject(ProjectCont, classcontainer, _textEditor, search, displayhelp);
            open.OpnenNewProject();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            SaveFile(_textEditor, _textEditor.Tag.ToString());
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            saveAs_file(_textEditor);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();// get the current texteditor
            SaveAll();
        }

        private void fromSolutionExpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Removefromsolution(); 
        }
        public void Removefromsolution()
        {
            TreeNode project;
            FileAttributes attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());

            //detect whether its a directory or file
            project = (attr & FileAttributes.Directory) != FileAttributes.Directory ? ProjectCont.SelectedNode.Parent : ProjectCont.SelectedNode;
            var confirmResult = MessageBox.Show("Are you sure want to delete [ " + project.Text + " Project ]?",
                                            "Confirm deleting",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                if (project != null)
                {
                    var directoryinfo = new DirectoryInfo(project.Tag.ToString());
                    directoryinfo.GetDirectories();
                    foreach (var file in directoryinfo.GetFiles())
                    {
                        foreach (TabPage tabp in classcontainer.TabPages)
                        {
                            if (file.FullName.Equals(tabp.Tag.ToString()))

                                _fochild.RemoveTab(tabp);
                        }
                    }
                    _create.RemoveFolder(ProjectCont, project);
                    var p = new Progressform("Deleting Project", 100);
                    p.Show();
                }
                else
                    MessageBox.Show("Please select project to remove.", "Select project", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void fromComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFromcomputer();   
        }
        public void RemoveFromcomputer()
        {
            TreeNode project;
            var attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());
            if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                project = ProjectCont.SelectedNode.Parent;
            else
                project = ProjectCont.SelectedNode;
            var confirmResult = MessageBox.Show("Are you sure want to delete [ " + project.Text + " Project]?",
                                           "Confirm deleting",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {

                if (project != null)
                {
                    var directoryinfo = new DirectoryInfo(project.Tag.ToString());
                    directoryinfo.GetDirectories();
                    foreach (FileInfo file in directoryinfo.GetFiles())
                    {
                        foreach (TabPage tabp in classcontainer.TabPages)
                        {
                            if (file.FullName.Equals(tabp.Tag.ToString()))

                                _fochild.RemoveTab(tabp);
                        }
                    }
                    var p = new Progressform("Deleting Project", Getlength(project.Tag.ToString()));
                    p.Show();
                    _create.Removefolderfromcomputer(ProjectCont, project, project.Tag.ToString());

                }
                else
                {
                    MessageBox.Show("Please select folder", "Select folder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            _textEditor.Redo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            _textEditor.Undo();
        }

        private void addClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClass();
        }
        private void AddClassButton_Click(object sender, EventArgs e)
        {
            AddClass();
        }

        private void Background_Colourutton4_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            colorDialog1.ShowDialog();
            _textEditor.BackColor = colorDialog1.Color;
        }

        private void Numbered_line_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            var font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(_textEditor.Text))
            {
                _textEditor.Font = font.Font;
            }
        }

        private void numberedLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _textEditor = GetEditor();
            var font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(_textEditor.Text))
            {
                _textEditor.Font = font.Font;
            }
        }

        public FastColoredTextBox GetEditor()
        {
            if (classcontainer.TabCount == 0) return null;
            FastColoredTextBox editor = null;
            var tab = classcontainer.SelectedTab;
            if (tab != null)
            {
                editor = tab.Controls[0] as FastColoredTextBox;
            }
            return editor;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetEditor().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetEditor().Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetEditor().Paste();
        }
        
        private void ESTF_Load(object sender, EventArgs e)
        {
            if (TabPage())
            {
                foreach (TabPage tab in classcontainer.TabPages)
                {
                    _textEditor = tab.Controls[0] as FastColoredTextBox;
                    _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                    _textEditor.TextChangedDelayed += fastColoredTextBox1_TextChangedDelayed;
                    classcontainer.MouseClick += ClassCont_MouseClick;
                }
               
            } else
            {
                AddClass(true);
            }
            _fochild.Searchtext.GotFocus += RemoveText;
            _fochild.Searchtext.LostFocus += AddText;
            
        }
        public bool TabPage()
        {
            return classcontainer.TabPages.Count > 0;
        }

        TabPage _page;
        private void ClassCont_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (var i = 0; i < classcontainer.TabCount; ++i)
                {
                    if (classcontainer.GetTabRect(i).Contains(e.Location))
                    {
                       classcontainer.SelectTab(i);
                       _page = classcontainer.SelectedTab;
                        Close_tab.Show(classcontainer, e.Location);
                    }
                }
            }
            fastColoredTextBox1_TextChangedDelayed(sender, null);
        }

       private void ESTF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(MessageBox.Show("The application going to Exit and save the work. ", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK))
            {
                e.Cancel = true;
            }
        }

       private void ChildFormClosing(object sender, FormClosingEventArgs e)
       {
           Application.Exit();
       }

       private void ProjectCont_MouseDown(object sender, MouseEventArgs e)
        {
            ProjectCont.SelectedNode = ProjectCont.GetNodeAt(e.X, e.Y);
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            classcontainer.MouseClick += ClassCont_MouseClick;
            var create = new CreateProject(ProjectCont, this, ClassControl);
            create.Show();
        }

        private void removeClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveClass();
        }
        public void RemoveClass()
        {
            var attr = File.GetAttributes(ProjectCont.SelectedNode.Tag.ToString());

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
            {
                var confirmResult = MessageBox.Show("Are you sure want to delete [ " + ProjectCont.SelectedNode.Text + " Class ]??",
                                             "Confirm deleting",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (TabPage tabp in classcontainer.TabPages)
                    {
                        if (ProjectCont.SelectedNode.Tag==tabp.Tag)
                           
                            _fochild.RemoveTab(tabp);
                    }
                    var file = new FileInfo(ProjectCont.SelectedNode.Tag.ToString());
                    double length = file.Length;
                    remove_class(ProjectCont.SelectedNode, ProjectCont.SelectedNode.Tag.ToString());
                    var p = new Progressform("Deleting Project", length);
                    p.Show();
                }

            }
            else
            {
                MessageBox.Show("Please select a class.", "Select class", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void remove_class(TreeNode nodeselected, string classPath1)
        {
            nodeselected.Remove();

            if (File.Exists(classPath1))
            {
                try
                {
                    File.Delete(classPath1);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
       {
           RemoveClass();  
       }

       public void fastColoredTextBox1_TextChangedDelayed(object sender, TextChangedEventArgs e)
       {
            //   MessageBox.Show("You are typing now :)");//method when you are typing 
            _textEditor = GetEditor();

            if (_textEditor == null) return;
            SaveFile_realTime(_textEditor, _textEditor.Tag.ToString());
            // MessageBox.Show("You are typing now 2 :)");
            var file = _textEditor.Tag.ToString();
            if (Getextension(_textEditor).Equals("Java"))
            {//run the project
             //  MessageBox.Show("You are typing now ww2 :)");
                _compilingJava = new Compiling(file);
                var s = _compilingJava.CompilingJavaCode();
                if (s.Equals(""))
                {
                    int[] line = { -1 };
                    SetLines(line);
                    _textEditor.PaintLine += fastColoredTextBox1_PaintLine;

                    _fochild.Errortext.Text = "";
                }
                else
                {
                    //  MessageBox.Show(s);
                    var bugs = new ErrorDetector(s, Path.GetFileName(file));
                    var res = bugs.GetResult();
                    fillInErrorTextBox(res, file);
                    var s1 = "";
                    for (var i = 0; i < res.GetLength(0); i += 1)
                    {
                        //   s1 += res.GetLength(i)+"   : ";
                        for (int j = 0; j < res.GetLength(1); j++)
                        {
                            s1 += res[i, j] + " - ";
                        }
                        s1 += '\n';
                    }
                    //   MessageBox.Show("Errors:: " + s1);
                    var errorLines = new int[res.GetLength(0)];
                    for (var i = 0; i < res.GetLength(0); i += 1)
                    {
                        errorLines[i] = Convert.ToInt32(res[i, 0]) - 1;
                    }
                    SetLines(errorLines);
                    _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                }
            }
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
       {
           _fochild.RemoveTab(_page);
       }

       private void Cut_Click(object sender, EventArgs e)
       {
           GetEditor().Cut();
       }

       private void toolStripLabel1_Click(object sender, EventArgs e)
       {
           GetEditor().Copy();
       }

       private void toolStripLabel2_Click(object sender, EventArgs e)
       {
           GetEditor().Paste();
       }

       private void toolStripButton5_Click(object sender, EventArgs e)
       {
           GetEditor().ShowFindDialog();
       }

       private void findToolStripMenuItem_Click(object sender, EventArgs e)
       {
           GetEditor().ShowFindDialog();
       }

       private void ESTF_FormClosed(object sender, FormClosedEventArgs e)
       {
           SaveAll();
           Application.Exit();
       }

       //Murtada last Version
       private Compiling _compilingJava;
       private readonly Running _runJava = new Running();
        internal static string[] duckNodes;
        internal static Dictionary<string, string> feedbackNodes;

        private void run(string file)
       {
           _fochild.richTextBox3.Text = "";
           _fochild.richTextBox4.Text = "";
          // _fochild.richTextBox2.Text = "";
           _fochild.Errortext.Text = "";
           if (Getextension(_textEditor).Equals("Java"))
           {//run the project
               var p = new ImplementPMD();
               var xml = p.RunPMD(Path.GetDirectoryName(file), Path.GetFileName(file));
               var xmlDoc = new XmlDocument();
               xmlDoc.LoadXml(xml);
               GenerateFeedbackOutput(_fochild.richTextBox3, xmlDoc);
               _compilingJava = new Compiling(file);
               var s = _compilingJava.CompilingJavaCode();
            
               if (s.Equals(""))
               {
                   //  var p = new ImplementPMD(file);
                   //  var xml =  p.RunPMD(Path.GetDirectoryName(file), Path.GetFileName(file));
                   //  var xmlDoc = new XmlDocument();
                   //  xmlDoc.LoadXml(xml);
                   //  GenerateFeedbackOutput(_fochild.richTextBox3,xmlDoc);
                   var style = new JavaCompilingToolMurtada.StyleChecker.ImplementStyleChecker(file);
                   // _fochild.richTextBox2.Text = style.StyleJavaCodeFeedback();
                   _fochild.richTextBox4.Text = _runJava.RunJavaProject(file);
               }
               else
               {
                   //   MessageBox.Show(s);
                   //  _fochild.Errortext.Text = s;
                   var bugs = new ErrorDetector(s, Path.GetFileName(file));
                   var res = bugs.GetResult();
                  
                   //   MessageBox.Show("Errors:: " + s1);
                   var errorLines = new int[res.GetLength(0)];
                   for (var i = 0; i < res.GetLength(0); i += 1)
                   {
                       errorLines[i] = Convert.ToInt32(res[i, 0]) - 1;
                   }
                   SetLines(errorLines);
                   var totalErrorCount = res.Length / 3;
                   _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                   const float bigFont = 12.0f;
                   var richTextBox = _fochild.Errortext;
                   var fontOriginal = richTextBox.Font.Size;
                   richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Underline);
                   richTextBox.AppendText("Total Errors found: " + totalErrorCount + "\n\n");
                   richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);
                   for (var errorIndex = 0; errorIndex < totalErrorCount; errorIndex++)
                   {
                       
                       var errorLine = Convert.ToInt32(res[errorIndex, 0]);
                       var errorSomething = res[errorIndex,1];
                       var error = res[errorIndex,2];

                       richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Bold);
                       richTextBox.AppendText("Error ");
                       richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Regular);
                       richTextBox.AppendText((errorIndex + 1)+ "\n\n");
                       richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);

                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                       richTextBox.AppendText("In file: ");
                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                       richTextBox.AppendText(file + "\n");


                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                       richTextBox.AppendText("On line nr: ");
                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                       richTextBox.AppendText(errorLine + "\n");

                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                       richTextBox.AppendText("Details:\n");
                       richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);

                       int asd = error.IndexOf("error:");
                       richTextBox.AppendText(error.Substring(asd + 7) + "\n");
                       richTextBox.AppendText("\n");
                   }
               }
               if (s.Equals(""))
               {
                   //  var p = new ImplementPMD(file);
                   //  var xml =  p.RunPMD(Path.GetDirectoryName(file), Path.GetFileName(file));
                   //  var xmlDoc = new XmlDocument();
                   //  xmlDoc.LoadXml(xml);
                   //  GenerateFeedbackOutput(_fochild.richTextBox3,xmlDoc);
                   var style = new JavaCompilingToolMurtada.StyleChecker.ImplementStyleChecker(file);
                   // _fochild.richTextBox2.Text = style.StyleJavaCodeFeedback();
                   _fochild.richTextBox4.Text = _runJava.RunJavaProject(file);
               }
               else
               {
                   var bugs = new ErrorDetector(s, Path.GetFileName(file));
                   var res = bugs.GetResult();

                   //   MessageBox.Show("Errors:: " + s1);
                   var errorLines = new int[res.GetLength(0)];
                   for (var i = 0; i < res.GetLength(0); i += 1)
                   {
                       errorLines[i] = Convert.ToInt32(res[i, 0]) - 1;
                   }
                   SetLines(errorLines);
                   _textEditor.PaintLine += fastColoredTextBox1_PaintLine;
                   fillInErrorTextBox(res,file);
               }
           }
           else
           {
               _textEditor = GetEditor();

               JavaCompilingToolMurtada.CSharpRunner.CSharpRunner cs = new JavaCompilingToolMurtada.CSharpRunner.CSharpRunner(_textEditor.Text);
               _fochild.richTextBox4.Text =cs.Compile(_textEditor.Text);
           }
       }

        private void fillInErrorTextBox(string[,] res, string file)
        {
            const float bigFont = 12.0f;
            var totalErrorCount = res.Length / 3;
            var richTextBox = _fochild.Errortext;
            richTextBox.Text="";
            var fontOriginal = richTextBox.Font.Size;
            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Underline);
            richTextBox.AppendText("Total Errors found: " + totalErrorCount + "\n\n");
            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);
            for (var errorIndex = 0; errorIndex < totalErrorCount; errorIndex++)
            {

                var errorLine = Convert.ToInt32(res[errorIndex, 0]);
                var errorSomething = res[errorIndex, 1];
                var error = res[errorIndex, 2];

                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Bold);
                richTextBox.AppendText("Error ");
                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Regular);
                richTextBox.AppendText((errorIndex + 1) + "\n\n");
                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);

                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                richTextBox.AppendText("In file: ");
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                richTextBox.AppendText(file + "\n");


                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                richTextBox.AppendText("On line nr: ");
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                richTextBox.AppendText(errorLine + "\n");

                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                richTextBox.AppendText("Details:\n");
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);

                int asd = error.IndexOf("error:");
                richTextBox.AppendText(error.Substring(asd + 7) + "\n");
                richTextBox.AppendText("\n");
            }
        }

        private void GenerateFeedbackOutput(RichTextBox richTextBox, XmlDocument xmlDoc)
        {
            var errorIndex = 0;
            var totalErrorCount = countErrors(xmlDoc);
            const float bigFont = 12.0f;
            var fontOriginal = richTextBox.Font.Size;

            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Underline);
            richTextBox.AppendText("Total warnings found: "+totalErrorCount+ "\n\n");
            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);

            foreach (XmlNode mainNode in xmlDoc.ChildNodes)
            {
                if ("pmd" == mainNode.Name)
                {
                    foreach(XmlNode fileNode in mainNode.ChildNodes)
                    {
                        foreach(XmlNode violationNode in fileNode.ChildNodes)
                        {
                            errorIndex++;
                            if (violationNode.Attributes == null)
                            {
                                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Bold);
                                richTextBox.AppendText("Big Warning ");
                                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Regular);
                                richTextBox.AppendText(errorIndex + "\n\n");
                                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                richTextBox.AppendText("Please fix the errors in your code and then try to compile again");
                            }
                            else
                            {
                                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Bold);
                                richTextBox.AppendText("Warning ");
                                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, bigFont, FontStyle.Regular);
                                richTextBox.AppendText(errorIndex + "\n\n");
                                richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, fontOriginal, FontStyle.Regular);

                                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                richTextBox.AppendText("In file: ");
                                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                                richTextBox.AppendText(violationNode.Attributes["class"].Value + "\n");

                                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                richTextBox.AppendText("On line nr: ");
                                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                                richTextBox.AppendText(violationNode.Attributes["beginline"].Value + "\n");

                                if (feedbackNodes.ContainsKey(violationNode.Attributes["rule"].Value))
                                {
                                    if (feedbackNodes[violationNode.Attributes["rule"].Value] != null && //
                                    feedbackNodes[violationNode.Attributes["rule"].Value].Length > 0)
                                    {
                                        richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                        richTextBox.AppendText("Details:");
                                        richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                                        richTextBox.AppendText(feedbackNodes[violationNode.Attributes["rule"].Value] + "\n");
                                    }
                                    else
                                    {
                                        richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                        richTextBox.AppendText("Details ");
                                        richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                                        richTextBox.AppendText(violationNode.FirstChild.InnerText + "\n");
                                    }
                                }
                                else
                                {
                                    richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                                    richTextBox.AppendText("Details:");
                                    richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                                    richTextBox.AppendText(violationNode.FirstChild.InnerText + "\n");
                                }
                            }
                        }
                        
                    }
                }
                
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This is a prototype educational software developed by Alex Dziubek. Contact email address: aleksandra.dziubek@northampton.ac.uk",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int countErrors(XmlDocument xmlDoc)
        {
            var errors = 0;
            foreach (XmlNode mainNode in xmlDoc.ChildNodes)
            {
                if ("pmd" == mainNode.Name)
                {
                    foreach (XmlNode fileNode in mainNode.ChildNodes)
                    {
                        foreach (var violationNode in fileNode.ChildNodes)
                        {
                            errors++;
                        }
                    }
                }
            }
            return errors;
        }
    }
}
