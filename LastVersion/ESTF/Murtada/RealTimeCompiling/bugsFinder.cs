using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace JavaCompilingToolMurtada.RealTimeCompiling
{
    class BugsFinder
    {
        private readonly string[] _error;
        private readonly string[,] _result;
        private readonly string _fileName;

        public BugsFinder(string err, string filename)
        {
            _fileName = filename;
            _error = err.Split(new[] {_fileName + ':'}, StringSplitOptions.None);
            _result = new string[Regex.Matches(err, _fileName).Count, 3];
            for (var i = 0; i < _error.Length; i++)
                if (_error[i].Length == 0) continue;
                else _error[i] = _fileName + ':' + _error[i];
            Extraction();
        }

        private void Extraction()
        {
            if (_error.Length <= 0)
                return;
            int count = 0;
            foreach (var t in _error)
            {
//MessageBox.Show("111:: " + Error[i]);

                string[] lines = t.Split('\n');
                for (int j = 0; j < lines.Length; j++)
                {
                    //    MessageBox.Show("filw:: " + lines[j]);
                    lines[j] = lines[j].Replace("\r", "");
                    if (lines[j].Contains(_fileName + ':'))
                    {
                        //extract the number of  line

                        lines[j] = lines[j].Substring((_fileName + ':').Length,
                            lines[j].Length - (_fileName + ':').Length);
                        _result[count, 0] = lines[j].Substring(0, lines[j].IndexOf(":"));
                        //extract the reason
                        _result[count, 2] = lines[j].Substring(0, lines[j].Length);
                    }

                    if (lines[j].Contains("^"))
                    {
                        //extract the column
                        _result[count++, 1] = lines[j].IndexOf("^") + "";
                    }
                }
            }
        }

        public string[,] GetResult()
        {
            return _result;
        }

        private void ExtractLineNumber()
        {

            for (int i = 0, j = 0; i < _error.Length; i += 3, j++)
            {
                var ErrorRow = (from t in _error[i] where char.IsDigit(t) select t).ToArray();
                _result[j, 0] = new string(ErrorRow);
            }
        }

        private void ExtractErrorColumn()
        {
            for (int i = 2, j = 0; i < _error.Length; i += 3, j++)
            {
                _result[j, 1] = _error[i].IndexOf('^') + "";
            }
        }

    }

}

