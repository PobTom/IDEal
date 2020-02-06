using System;
using System.Windows.Forms;

namespace Ideal
{
    public partial class DuckForm : Form
    {
        readonly string[] _duckNodes;
        int _index;
        public DuckForm(string[] duckNodes)
        {
            _duckNodes = duckNodes;
            InitializeComponent();
            FillDetails(GetNextDuckQuestion());
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            FillDetails(GetNextDuckQuestion());
        }

        private void FillDetails(string question)
        {
            if (_index == _duckNodes.Length)
            {
                nextButton.Text = "Finish";
                duckAnswerTextBox.Hide();
            }
            if (question == null)
            {
                Close();
            } else
            {
                duckQuestionLabel.Text = question;
                duckAnswerTextBox.Text = "";
            }
        }

        private string GetNextDuckQuestion()
        {
            if (_index > _duckNodes.Length-1)
            {
                _index = -1; // final version
                return null;
            }

            return _duckNodes[_index++];
        }
    }
}
