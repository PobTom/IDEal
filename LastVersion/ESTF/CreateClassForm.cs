using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Ideal
{
    public partial class CreateClassForm : Form
    {
        private readonly TreeNode _folder;
        private readonly TabControl _tab;
        private readonly string _folderPath = "";
        private bool _flag;
        public string hoveredWord;

        FastColoredTextBox _textEditor;
        RichTextBox _helper = new RichTextBox();
        TextBox _search = new TextBox();

        /// </summary>
        /// <param name="folderpath"></param>
        /// <param name="folder"></param>
        /// <param name="tab"></param>
        /// <param name="search"></param>
        /// <param name="helper"></param>
        /// <param name="texteditor"></param>
        /// 
        readonly string[] _keywords =
        {
            "abstract", "add", "alias", "as", "ascending", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate",  "descending", "do", "double", "dynamic", "else", "enum", "event", "explicit", 
            "extern", "false", "finally", "fixed", "float", "for", "foreach", "from", "get", "global", "goto", "group", "if", "implicit", 
            "in", "int", "into", "is", "join", "let", "lock", "long", "namespace", "new", "null", "object", "operator", "orderby", "out", 
            "override", "params", "partial", "private", "protected", "public", "readonly", "ref", "remove", "return", "sbyte", "sealed",
            "select", "set", "short", "sizeof", "stackalloc", "static", "String", "struct", "switch", "this", "throw", "true", "try", 
            "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "value", "virtual", "void", "volatile", "while",            
            "where", "yield"
        };

        List<string> _methods = null;

        public void generateMethods()
        {
            _methods = new List<string>();
            var doc = new XmlDocument();
            doc.Load(@"methodsAutocompletion.xml");
            var nodes = doc.SelectNodes("methods/method");
            foreach (XmlNode node in nodes)
            {
                _methods.Add(node.InnerText);
            }
        }

        public readonly string[] snippets =
        {
            "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}", "for(^;;)\n{\n;\n}", "while(^)\n{\n;\n}",
            "do${\n^;\n}while();", "switch(^)\n{\ncase : break;\n}"
        };

        readonly string[] _declarationSnippets =
        {
            "public class ^\n{\n}", "private class ^\n{\n}",
            "public struct ^\n{\n;\n}", "private struct ^\n{\n;\n}",
            "public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
            "public ^{ get; set; }", "private ^{ get; set; }", "protected ^{ get; set; }"
        };

        private readonly ImageList _image;

        public CreateClassForm(string folderPath, TreeNode folder, TabControl tab, TextBox search, RichTextBox helper, FastColoredTextBox texteditor, ImageList imageList, RichTextBox feedback)
        {
            _tab = tab;
            _folder = folder;
            _folderPath = folderPath;
            _search = search;
            _helper = helper;
            _textEditor = texteditor;
            _image = imageList;
            InitializeComponent();
            ReadXml();
        }

        public CreateClassForm()
        {
            InitializeComponent();
            ReadXml();
        }

        public CreateClassForm(TextBox textb, RichTextBox helper)
        {
            InitializeComponent();
            _search = textb;
            _helper = helper;
            ReadXml();
        }

        private void BuildAutocompleteMenu()
        {
            generateMethods();
            var items = snippets.Select(item => new SnippetAutocompleteItem(item) {ImageIndex = 1})
                .Cast<AutocompleteItem>().ToList();
            items.AddRange(_declarationSnippets.Select(item => new DeclarationSnippet(item) {ImageIndex = 0}));

            //items.AddRange(_methods.Select(item => new MethodAutocompleteItem(item) { ImageIndex = 2 }));
            items.AddRange(_methods.Select(item => new PrjMethodAutocompleteItem(item) { ImageIndex = 2}));
            items.AddRange(_keywords.Select(item => new AutocompleteItem(item)));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            _popupMenu.Items.SetAutocompleteItems(items);
        }

        public void ReadXml()
        {
            var doc = new XmlDocument();

            doc.Load(@"XMLFile1.xml");

            var nodes = doc.SelectNodes("keywords/keyword");
            foreach (XmlNode node in nodes)
            {
                var keywordName = node.SelectSingleNode("name");
                var keywordDescription = node.SelectSingleNode("l_discription");
                var example = node.SelectSingleNode("Example");
                _dict.Add(keywordName.InnerText,
                    GetEntryText(keywordDescription.InnerText + "\n e.g." + example.InnerText));
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(classNameBox.Text, "[^a-z0-9]", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Name contains invalid characters. Only letters and numbers are allowed.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (classNameBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter a class name.","Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var text = @" public class " + classNameBox.Text +
                               "\n{\n \t public static void main(String[] args) \n \t{ \n \t \t //type your code here e.g \n \t \t System.out.println(\"hello world\");\n \t} \n}";

                    AddClass(_folder, _textEditor, classNameBox.Text, _folderPath, _tab, text);
                }
            }
        }

        public void AddClass(TreeNode folder, FastColoredTextBox textEditor, string classname, string folderPath,
            TabControl tab, string text)
        {
            var path = SetPath( folderPath, classname);

                textEditor = AddTextEditor(textEditor, classname, folder.Text, text);
                textEditor.Tag = path;
                textEditor.ToolTipNeeded += fastColoredTextBox1_ToolTipNeeded;
                textEditor.MouseDoubleClick += Codeeditor_MouseDoubleClick;

                AddClassToDirectory(folderPath, classname, textEditor);
                if (_flag)
                {

                    folder.Nodes.Add(AddSubNoode(classname, path));
                    AddTabPage(classname, tab, textEditor);

                    Close();
                }
                else
                {
                    MessageBox.Show("The file cannot be created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //create method to add class as a child node 
        public TreeNode AddSubNoode(string classname, string Pathname)
        {
            return new TreeNode
            {
                Tag = Pathname, Text = classname, ImageKey = "Docs-icon.png", SelectedImageIndex = 1
            };
        }

        //add new tab page to the tabcontrol with each class
        public void AddTabPage(string classname, TabControl tab, FastColoredTextBox texteditor)
        {
            var tabPage = new TabPage();
            tabPage.Text = classname;
            tabPage.Tag = texteditor.Tag;
            tab.Controls.Add(tabPage);
            tab.SelectTab(tabPage);
            tabPage.Controls.Add(texteditor);

        }

        //method add texteditor to the tabpage with each class will be created 
        AutocompleteMenu _popupMenu;

        public FastColoredTextBox AddTextEditor(FastColoredTextBox texteditor, string classname, string projectname,
            string text)
        {
            texteditor.Name = classname;
            texteditor.Dock = DockStyle.Fill;
            ColourCoding(texteditor);
            texteditor.Text = text;
            PopupMenu(texteditor);
            return texteditor;
        }

        public void ColourCoding(FastColoredTextBox texteditor)
        {
            texteditor.Language = Language.CSharp;
            texteditor.AutoIndentNeeded -= fastColoredTextBox1_AutoIndentNeeded;

            texteditor.AutoIndentChars = true;
            texteditor.AutoIndentCharsPatterns = @"^\s*\w+\s+(?<range>[^,]+)\s*,?\s*(?<range>.+)?";

            texteditor.GoEnd();
            texteditor.Focus();
        }

        public void PopupMenu(FastColoredTextBox texteditor)
        {
            _popupMenu = new AutocompleteMenu(texteditor);
            _popupMenu.Items.ImageList = _image;
            _popupMenu.SearchPattern = @"[\w\.:=!<>]";
            _popupMenu.AllowTabKey = true;
            //
            BuildAutocompleteMenu();

        }

       public void AddClassToDirectory(string Pathname, string classname, FastColoredTextBox texteditor)
        {
            var path = SetPath(Pathname, classname);

            if (!File.Exists(path))
            {
                try
                {
                    var sw = new StreamWriter(@path);
                    sw.Write(texteditor.Text);
                    sw.Close();
                    _flag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _flag = false;
                }
            }
            else
            {
                MessageBox.Show("File already exists!", "File exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _flag = false;
            }
        }

        public string SetPath(string Pathname, string classname)
        {
            return Path.Combine(Pathname, classname + ".java");
        }

        public void OpenClass(string fileName, TabControl tab, FastColoredTextBox textEditor, string directoryInfoName,
            string text, string path)
        {
            textEditor = AddTextEditor(textEditor, fileName, directoryInfoName, text);
            textEditor.Tag = path;
            textEditor.ToolTipNeeded += fastColoredTextBox1_ToolTipNeeded;
            textEditor.MouseDoubleClick += Codeeditor_MouseDoubleClick;

            AddTabPage(fileName, tab, textEditor);


        }

        int[] _line = {1, 2, 5};

        public void SetLines(int[] line)
        {
            _line = line;
        }

        string[] _error = {"hello", "talked", "like"};

        private void fastColoredTextBox1_PaintLine(object sender, PaintLineEventArgs e)
        {
            int i = 0;
            while (i < _line.Length)
            {
                if (e.LineIndex == _line[i])
                {

                    var projectWindow = new ProjectWindow();
                    //projectWindow.Populate("");
                    Brush brush;
                    using (brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.LightPink,
                        Color.Red, 45))
                        e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
                    var x = 0;
                    while (x <= i)
                    {
                        projectWindow.feedback.Text += _error[x];
                        //  projectWindow.Populate(projectWindow.feedback.Text);
                          //  _fochild.Errortext.Text += feedback.Text;
                        x++;
                    }
                }

                i++;
            }
        }

        public void fastColoredTextBox1_AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            _popupMenu.Show(true);
            // if previous line contains "then" or "else", 
            // and current line does not contain "begin"
            // then shift current line to right
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }

            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }

            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }

            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) //operator is unclosed
                {
                    args.Shift = args.TabLength;
                }
        }

        Dictionary<string, string> _dict = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

        public void fastColoredTextBox1_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {

            if (!string.IsNullOrEmpty(e.HoveredWord))
            {
                e.ToolTipTitle = e.HoveredWord;
                if (_dict.ContainsKey(e.HoveredWord))
                {
                    e.ToolTipText = _dict[e.HoveredWord];
                }

                hoveredWord = e.HoveredWord;
            }
        }

        int _lineBreakIndex = 60;

        private string GetEntryText(string key)
        {
            var s = key;
            var lastLineEnd = _lineBreakIndex;
            for (var i = lastLineEnd; i < s.Length; i += _lineBreakIndex)
            {
                while (s[i] != ' ')
                {
                    if (--i < 0) break;
                }

                i++;
                s = s.Insert(i, "\n");
            }

            return s;
        }

        public void Codeeditor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _search.Text = hoveredWord;
            hoveredWord = "";
            //ReadXmlToHelper(_search.Text.ToLower());
            ReadXmlToHelper(_search.Text);
        }

        public void ReadXmlToHelper(string text)
        {
            string file =ProjectEditor.getRtfKeywordFile(text);
            if (file != null)
            {
                _helper.LoadFile(file);
            } else
            {
                _helper.Text = "Sorry, No result";
            }
        }

    }

    /// <summary>
    /// This item appears when any part of snippet text is typed
    /// </summary>
    class DeclarationSnippet : SnippetAutocompleteItem
    {
        public DeclarationSnippet(string snippet)
            : base(snippet)
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var pattern = Regex.Escape(fragmentText);
            if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                return CompareResult.Visible;
            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// Divides numbers and words: "123AND456" -> "123 AND 456"
    /// Or "i=2" -> "i = 2"
    /// </summary>
    class InsertSpaceSnippet : AutocompleteItem
    {
        string pattern;
        public InsertSpaceSnippet(string pattern) : base("")
        {
            this.pattern = pattern;
        }

        public InsertSpaceSnippet()
            : this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (Regex.IsMatch(fragmentText, pattern))
            {
                Text = InsertSpaces(fragmentText);
                if (Text != fragmentText)
                    return CompareResult.Visible;
            }

            return CompareResult.Hidden;
        }

        public string InsertSpaces(string fragment)
        {
            var m = Regex.Match(fragment, pattern);
            if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                return fragment;
            return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
        }

        public override string ToolTipTitle
        {
            get { return Text; }
        }
    }

    /// <summary>
    /// Inerts line break after '}'
    /// </summary>
    class InsertEnterSnippet : AutocompleteItem
    {
        Place _enterPlace = Place.Empty;

        public InsertEnterSnippet()
            : base("[Line break]")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var r = Parent.Fragment.Clone();
            while (r.Start.iChar > 0)
            {
                if (r.CharBeforeStart == '}')
                {
                    _enterPlace = r.Start;
                    return CompareResult.Visible;
                }

                r.GoLeftThroughFolded();
            }

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            //extend range
            var r = Parent.Fragment;
            r.Start = _enterPlace;
            r.End = r.End;
            //insert line break
            return Environment.NewLine + r.Text;
        }

        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            base.OnSelected(popupMenu, e);
            if (Parent.Fragment.tb.AutoIndent)
                Parent.Fragment.tb.DoAutoIndent();
        }

        public override string ToolTipTitle
        {
            get { return "Insert line break after '}'"; }
        }
    }
}
