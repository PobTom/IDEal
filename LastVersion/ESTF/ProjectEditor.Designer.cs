namespace Ideal
{
    partial class ProjectEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ClassCont = new System.Windows.Forms.TabControl();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Error = new System.Windows.Forms.TabControl();
            this.Output = new System.Windows.Forms.TabPage();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Errortext = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.emailButton = new System.Windows.Forms.Button();
            this.Displayhelptext = new System.Windows.Forms.RichTextBox();
            this.emailTutorButton = new System.Windows.Forms.Button();
            this.askDuckButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gogoleSearchButton = new System.Windows.Forms.Button();
            this.googleTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Searchtext = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Error.SuspendLayout();
            this.Output.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ClassCont);
            this.splitContainer1.Panel1.Controls.Add(this.splitter2);
            this.splitContainer1.Panel1.Controls.Add(this.Error);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(784, 448);
            this.splitContainer1.SplitterDistance = 606;
            this.splitContainer1.TabIndex = 0;
            // 
            // ClassCont
            // 
            this.ClassCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassCont.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassCont.Location = new System.Drawing.Point(0, 0);
            this.ClassCont.Name = "ClassCont";
            this.ClassCont.SelectedIndex = 0;
            this.ClassCont.Size = new System.Drawing.Size(602, 285);
            this.ClassCont.TabIndex = 4;
            // 
            // splitter2
            // 
            this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 285);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(602, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // Error
            // 
            this.Error.Controls.Add(this.Output);
            this.Error.Controls.Add(this.tabPage2);
            this.Error.Controls.Add(this.tabPage1);
            this.Error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Error.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error.Location = new System.Drawing.Point(0, 288);
            this.Error.Name = "Error";
            this.Error.SelectedIndex = 0;
            this.Error.Size = new System.Drawing.Size(602, 153);
            this.Error.TabIndex = 2;
            // 
            // Output
            // 
            this.Output.Controls.Add(this.richTextBox4);
            this.Output.Location = new System.Drawing.Point(4, 26);
            this.Output.Name = "Output";
            this.Output.Padding = new System.Windows.Forms.Padding(3);
            this.Output.Size = new System.Drawing.Size(594, 123);
            this.Output.TabIndex = 0;
            this.Output.Text = "Output";
            this.Output.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.Location = new System.Drawing.Point(3, 3);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(588, 117);
            this.richTextBox4.TabIndex = 2;
            this.richTextBox4.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(594, 123);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Suggestions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(3, 3);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(588, 117);
            this.richTextBox3.TabIndex = 2;
            this.richTextBox3.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Errortext);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(594, 123);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Errors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Errortext
            // 
            this.Errortext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Errortext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Errortext.Location = new System.Drawing.Point(0, 0);
            this.Errortext.Name = "Errortext";
            this.Errortext.ReadOnly = true;
            this.Errortext.Size = new System.Drawing.Size(594, 123);
            this.Errortext.TabIndex = 2;
            this.Errortext.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 441);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(602, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.emailButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Displayhelptext, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.emailTutorButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.askDuckButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 414);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // emailButton
            // 
            this.emailButton.AutoSize = true;
            this.emailButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailButton.Image = global::ESTF.Properties.Resources.mail_2_icon_16;
            this.emailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emailButton.Location = new System.Drawing.Point(1, 325);
            this.emailButton.Margin = new System.Windows.Forms.Padding(1);
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(168, 28);
            this.emailButton.TabIndex = 8;
            this.emailButton.Text = "Message a friend";
            this.emailButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.emailButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.emailButton.UseVisualStyleBackColor = true;
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // Displayhelptext
            // 
            this.Displayhelptext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Displayhelptext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Displayhelptext.Location = new System.Drawing.Point(3, 3);
            this.Displayhelptext.Name = "Displayhelptext";
            this.Displayhelptext.ReadOnly = true;
            this.Displayhelptext.Size = new System.Drawing.Size(164, 288);
            this.Displayhelptext.TabIndex = 1;
            this.Displayhelptext.Text = "Use the search box above to find the definitions of most common keywords with exa" +
    "mples";
            // 
            // emailTutorButton
            // 
            this.emailTutorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailTutorButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTutorButton.Image = global::ESTF.Properties.Resources.mail_2_icon_16;
            this.emailTutorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emailTutorButton.Location = new System.Drawing.Point(1, 355);
            this.emailTutorButton.Margin = new System.Windows.Forms.Padding(1);
            this.emailTutorButton.Name = "emailTutorButton";
            this.emailTutorButton.Size = new System.Drawing.Size(168, 28);
            this.emailTutorButton.TabIndex = 13;
            this.emailTutorButton.Text = "Message teacher";
            this.emailTutorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.emailTutorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.emailTutorButton.UseVisualStyleBackColor = true;
            this.emailTutorButton.Click += new System.EventHandler(this.emailTutorButton_Click);
            // 
            // askDuckButton
            // 
            this.askDuckButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.askDuckButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.askDuckButton.Image = global::ESTF.Properties.Resources.spechbubble_2_icon_16;
            this.askDuckButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.askDuckButton.Location = new System.Drawing.Point(1, 295);
            this.askDuckButton.Margin = new System.Windows.Forms.Padding(1);
            this.askDuckButton.Name = "askDuckButton";
            this.askDuckButton.Size = new System.Drawing.Size(168, 28);
            this.askDuckButton.TabIndex = 14;
            this.askDuckButton.Text = "Talk to The Duck";
            this.askDuckButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.askDuckButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.askDuckButton.UseVisualStyleBackColor = true;
            this.askDuckButton.Click += new System.EventHandler(this.askDuckButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Controls.Add(this.gogoleSearchButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.googleTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 387);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(164, 24);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // gogoleSearchButton
            // 
            this.gogoleSearchButton.AutoSize = true;
            this.gogoleSearchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gogoleSearchButton.BackgroundImage = global::ESTF.Properties.Resources.zoom_icon_32;
            this.gogoleSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gogoleSearchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.gogoleSearchButton.Location = new System.Drawing.Point(141, 0);
            this.gogoleSearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.gogoleSearchButton.Name = "gogoleSearchButton";
            this.gogoleSearchButton.Size = new System.Drawing.Size(23, 27);
            this.gogoleSearchButton.TabIndex = 0;
            this.gogoleSearchButton.Text = "  ";
            this.gogoleSearchButton.UseVisualStyleBackColor = true;
            this.gogoleSearchButton.Click += new System.EventHandler(this.gogoleSearchButton_Click);
            // 
            // googleTextBox
            // 
            this.googleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.googleTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.googleTextBox.Location = new System.Drawing.Point(1, 1);
            this.googleTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.googleTextBox.Name = "googleTextBox";
            this.googleTextBox.Size = new System.Drawing.Size(137, 25);
            this.googleTextBox.TabIndex = 16;
            this.googleTextBox.Text = "Ask Google...";
            this.googleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.googleTextBox, "Type your question and click the right button ->");
            this.googleTextBox.Enter += new System.EventHandler(this.googleTextBox_Enter);
            this.googleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.googleTextBox_KeyPress);
            this.googleTextBox.Leave += new System.EventHandler(this.googleTextBox_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Searchtext);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 30);
            this.panel1.TabIndex = 0;
            // 
            // Searchtext
            // 
            this.Searchtext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Searchtext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchtext.Location = new System.Drawing.Point(0, 0);
            this.Searchtext.Multiline = true;
            this.Searchtext.Name = "Searchtext";
            this.Searchtext.Size = new System.Drawing.Size(140, 30);
            this.Searchtext.TabIndex = 1;
            this.Searchtext.Text = "Search Wiki here...";
            this.toolTip1.SetToolTip(this.Searchtext, "search for help about keyword\r\nsearch in small letters.");
            this.Searchtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchText_KeyPress);
            // 
            // Search
            // 
            this.Search.BackgroundImage = global::ESTF.Properties.Resources.zoom_icon_32;
            this.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.Search.Location = new System.Drawing.Point(140, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(30, 30);
            this.Search.TabIndex = 0;
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(588, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 74);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(784, 448);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectEditor";
            this.ShowInTaskbar = false;
            this.Text = "Project";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Error.ResumeLayout(false);
            this.Output.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
         System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Search;
        public System.Windows.Forms.TextBox Searchtext;
        public System.Windows.Forms.RichTextBox Displayhelptext;
        private System.Windows.Forms.ToolTip toolTip1;
       // public System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl ClassCont;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button emailButton;
        private System.Windows.Forms.Button emailTutorButton;
        private System.Windows.Forms.Button askDuckButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button gogoleSearchButton;
        public System.Windows.Forms.TextBox googleTextBox;
        public System.Windows.Forms.TabControl Error;
        private System.Windows.Forms.TabPage Output;
        public System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.RichTextBox Errortext;
    }
}