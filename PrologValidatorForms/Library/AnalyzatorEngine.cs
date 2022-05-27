using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prolog;
using System.Windows.Forms;
using PrologValidatorForms.Library;

namespace PrologValidatorForms
{
    class Task
    {
        long sizeOfFile;
        string taskFilePath;
        string taskName;
        string creationDate;
        int correctAnswers = 0;
        int totalAnswers = 0;
        List<Test> tests = new List<Test>();

        public Task(string taskFilePath, string taskName)
        {
            this.taskFilePath = taskFilePath;
            this.taskName = taskName;
        }

        public List<Test> Tests
        {
            get { return tests; }
        }

        public long SizeOfFile
        {
            get { return sizeOfFile; }
        }

        public string TaskName
        {
            get { return taskName; }
        }

        public string CreationTime
        {
            get { return creationDate; }
        }

        public int CorrectAnswers
        {
            get { return correctAnswers; }
        }

        public int TotalAnswers
        {
            get { return totalAnswers; }
        }

        private void AddTest(string content, bool isCorrect)
        {
            totalAnswers++;
            if (isCorrect)
                correctAnswers++;
            tests.Add(new Test(content, isCorrect));
        }

        private bool AnylyzeArray(PrologEngine e, string current)
        {
            string query = "";
            string[] data = current.Split(' ');
            if (data.Length > 1)
                query = data[1];

            SolutionSet ss = e.GetAllSolutions(taskFilePath, query);
            List<string> values = new List<string>();

            foreach (Solution s in ss.NextSolution)
            {
                string answer = "";
                bool moreThan1 = false;

                foreach (Variable v in s.NextVariable)
                {
                    if (moreThan1)
                        answer += "+";
                    answer += v.Value;
                    moreThan1 = true;
                }
                values.Add(answer);
            }

            List<string> compArr = new List<string>();
            for (int i = 2; i < data.Length; i++)
            {
                compArr.Add(data[i]);
            }

            values.Sort();

            bool final = false;
            if (values.Count != 0 && values.Count == compArr.Count)
            {
                final = true;
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] != compArr[i])
                    {
                        final = false;
                        break;
                    }
                }
            }

            return final;
        }

        public void GetBasicInformations()
        {
            FileInfo fi = new FileInfo(taskFilePath);
            if (fi.Exists)
            {
                this.creationDate = fi.CreationTime.ToString();
                this.sizeOfFile = fi.Length;
            }
            else
            {
                this.creationDate = "Plik nie istnieje!";
                this.sizeOfFile = 0;
            }
        }

        public void AnalyzeTests(List<string> tests)
        {

            PrologEngine e = new PrologEngine();

            foreach (string test in tests)
            {
                bool final;
                if (test[0] == '$')
                {
                    final = AnylyzeArray(e, test);
                    this.AddTest(test, final);
                }
                else
                {
                    SolutionSet ssman = e.GetAllSolutions(taskFilePath, test);
                    final = ssman.Success;
                    this.AddTest(test, final);
                }
            }
        }


        public override string ToString()
        {
            if (taskFilePath != null)
                return taskName + "   |   " + taskFilePath + "\n" + ShowTests();
            return "";
        }

        private string ShowTests()
        {
            string result = "";
            for (int i = 0; i < tests.Count; i++)
            {
                result += $"     -{tests[i]}\n";
            }
            return result;
        }
    }

    class Test
    {
        string content;
        bool isCorrect;

        public string Content
        {
            get { return content; }
        }
        public int IsCorrect
        {
            get { if (isCorrect) { return 1; } else { return 0; } }
        }
        public Test(string content, bool isCorrect)
        {
            this.content = content;
            this.isCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"[ {content}   |   {isCorrect} ]";
        }
    }
}
