using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ideal
{
    public partial class LoadingScreen : Form
    {

        int _second = 0;
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            _second++;
            if (_second >= 50)
            {
                label3.Text = "Starting";
                var rnd = new Random();
                label3.ForeColor = Color.FromArgb((rnd.Next(0, 255)), (rnd.Next(0, 255)),
          (rnd.Next(0, 255)));
            }
            
        }
      }
}
