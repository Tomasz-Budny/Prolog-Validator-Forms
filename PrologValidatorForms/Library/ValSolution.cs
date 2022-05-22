using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string SolutionName
        {
            get { return solutionName; }
        }

        public List<Task> Tasks
        {
            get { return tasks; }
        }

        public ValSolution(string path, Label infoLabel, string finalPath, string keyPath)
        {
            this.path = path;
            this.infoLabel = infoLabel;
            this.finalPath = finalPath;
            this.keyPath = keyPath;
            solutionName = path.Substring(path.Length - 11, 11);
        }

        private string ShowTasks()
        {
            string result = "\n";
            for (int i = 0; i < tasks.Count; i++)
            {
                result += tasks[i].ToString() + "\n";
            }
            return result;
        }

        public void AnalyzeSolution()
        {
            AnalyzeTasks();
        }

        private void AnalyzeTasks()
        {
            StreamReader sr = new StreamReader(keyPath);
            string currentLine = "";

            while ((currentLine = sr.ReadLine()) != null)
            {
                string[] data = currentLine.Split(' ');
                if (data[0] == "!")
                {
                    if (InputValidator.ValidateTaskName(data[1]) == true)
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
                            Task task = new Task(null, $"{data[1]}.pl", Convert.ToInt32(data[2]), "Plik nie istnieje!", 0);
                            tasks.Add(task);
                        }
                    }
                    else
                    {
                        infoLabel.Text += $"plik: {data[1]} nie spełnia warunków konwencji: zadx.pl\n";
                    }
                }
            }
            if (tasks.Count == 0)
            {
                infoLabel.Text += "Nie znaleziono żadnego pliku z zadaniem!\n";
            }
            else
            {

            }

            // W celu testowania usunąć potem
            infoLabel.Text += ShowTasks();

            sr.Close();
        }

    }
}
