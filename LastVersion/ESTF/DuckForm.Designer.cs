namespace Ideal
{
    partial class DuckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuckForm));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.duckQuestionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.duckAnswerTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ESTF.Properties.Resources.textBubble2;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(168, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(337, 125);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // duckQuestionLabel
            // 
            this.duckQuestionLabel.BackColor = System.Drawing.Color.White;
            this.duckQuestionLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.duckQuestionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duckQuestionLabel.Location = new System.Drawing.Point(191, 56);
            this.duckQuestionLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.duckQuestionLabel.Name = "duckQuestionLabel";
            this.duckQuestionLabel.Size = new System.Drawing.Size(302, 82);
            this.duckQuestionLabel.TabIndex = 4;
            this.duckQuestionLabel.Text = "duckQuestionLabel";
            this.duckQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ESTF.Properties.Resources.rubber_duck;
            this.pictureBox1.Location = new System.Drawing.Point(48, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // duckAnswerTextBox
            // 
            this.duckAnswerTextBox.Location = new System.Drawing.Point(48, 166);
            this.duckAnswerTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.duckAnswerTextBox.Multiline = true;
            this.duckAnswerTextBox.Name = "duckAnswerTextBox";
            this.duckAnswerTextBox.Size = new System.Drawing.Size(480, 156);
            this.duckAnswerTextBox.TabIndex = 1;
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(453, 341);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 10;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // DuckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(586, 396);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.duckAnswerTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.duckQuestionLabel);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DuckForm";
            this.Text = "Talk to the Duck";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label duckQuestionLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.TextBox duckAnswerTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}