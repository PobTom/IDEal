using System;
using System.Windows.Forms;

namespace Ideal
{
    public partial class Progressform : Form
    {
        string Opration;
        double length;
        public Progressform(string Opration, double length)
        {
            InitializeComponent();
            this.Opration = Opration;
            this.length = length;
        }

        private void Progressform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1;
            
            progressBar1.Maximum = (int)length/10;
            timer1.Tick += timer1_Tick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value++;
                var percentage = (progressBar1.Value * 100) / progressBar1.Maximum;
                label1.Text = "Current progress: " + percentage + "%";
                Text = Opration;
            }
            else
            {
                timer1.Stop();
                Close();
            }
        }
    }
}
