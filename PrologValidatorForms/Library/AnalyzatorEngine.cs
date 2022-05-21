using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prolog;
using System.Windows.Forms;

namespace PrologValidatorForms
{
    class Task
    {
        long sizeOfFile;
        string taskPath;
        string taskName;
        string creationTime;
        int correctAnswers = 0;
        int totalAnswers = 0;
        List<Test> tests = new List<Test>();

        public Task(string taskPath, string taskName, int totalAnswers, string creationTime, long sizeOfFile)
        {
            this.totalAnswers = totalAnswers;
            this.taskName = taskName;
            this.taskPath = taskPath;
            this.creationTime = creationTime;
            this.sizeOfFile = sizeOfFile;
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
            get { return creationTime; }
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
            if (isCorrect)
                correctAnswers++;
            tests.Add(new Test(content, isCorrect));
        }

        public void AnalyzeTests(StreamReader sr, int iterations)
        {
            PrologEngine e = new PrologEngine();

            int i = 0;
            string currentLine = "";
            while(i < iterations && (currentLine = sr.ReadLine()) != null)
            {
                SolutionSet ssman = e.GetAllSolutions(taskPath, currentLine);
                if(ssman.Success)
                {
                    this.AddTest(currentLine, true);
                }
                else
                {
                    this.AddTest(currentLine, false);
                }
                i++;
            }
        }

        public override string ToString()
        {
            if(taskPath != null)
                return taskName + "   |   " + taskPath +"\n" + ShowTests();
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
