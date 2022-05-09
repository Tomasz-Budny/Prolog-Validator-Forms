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
    partial class ValSolution
    {
        string path;
        string solutionName;
        string keyPath;
        string finalPath;
        Label infoLabel;
        List<Task> tasks = new List<Task>();

        public ValSolution(string path, Label infoLabel, string finalPath)
        {
            this.path = path;
            this.infoLabel = infoLabel;
            this.finalPath = finalPath;
            solutionName = path.Substring(path.Length - 11, 11);
        }

        private string ShowTasks()
        {
            string result = "\n";
            for (int i = 0; i < tasks.Count; i++)
            {
                result += tasks[i].ToString()+"\n";
            }
            return result;
        }

        public void AnalyzeSolution()
        {
            FileInfo fi = new FileInfo(path + @"\klucz.txt");
            if (fi.Exists)
            {
                keyPath = path + @"\klucz.txt";
                AnalyzeTasks();
            }
            else
            {
                MessageBox.Show($"W ścieżce: {path} brak pliku klucz.txt!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                infoLabel.Text += "w katalogu z rozwiązaniem brak pliku: klucz.txt!\n";
            }
        }

        private void AnalyzeTasks()
        {
            StreamReader sr = new StreamReader(keyPath);
            string currentLine = "";

            while((currentLine = sr.ReadLine()) != null)
            {
                string[] data = currentLine.Split(' ');
                if(data[0] == "!")
                {
                    if(InputValidator.ValidateTaskName(data[1]) == true)
                    {
                        FileInfo fi = new FileInfo(path + $@"\{data[1]}.pl");
                        if (fi.Exists)
                        {
                            Task task = new Task(path + $@"\{data[1]}.pl", $"{data[1]}.pl", Convert.ToInt32(data[2]), fi.CreationTime.ToString(), fi.Length);
                            task.AnalyzeTests(sr, Convert.ToInt32(data[2]));
                            tasks.Add(task);
                        }
                        else
                        {
                            infoLabel.Text += $"Nie znaleziono pliku: {data[1]}.pl!\n";
                            Task task = new Task(null , $"{data[1]}.pl", Convert.ToInt32(data[2]), "Plik nie istnieje!", 0);
                            tasks.Add(task);
                        }
                    }
                    else
                    {
                        infoLabel.Text += $"plik: {data[1]} nie spełnia warunków konwencji: zadx.pl\n";
                    }
                }
            }
            if(tasks.Count == 0)
            {
                infoLabel.Text += "Nie znaleziono żadnego pliku z zadaniem!\n";
            }
            else
            {
                CreateExcelFile();
            }

            // W celu testowania usunąć potem
            infoLabel.Text += ShowTasks();

            sr.Close();
        }

    }

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
