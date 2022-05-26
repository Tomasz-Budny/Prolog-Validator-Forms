using PrologValidatorForms.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrologValidatorForms
{
    partial class StudentTasksManager
    {
        string path;
        string solutionName;
        int maxTestsCount;
        KeyManager keyManager;
        List<Task> tasks = new List<Task>();
        
        public int MaxTestCount
        {
            get { return maxTestsCount; }
        }

        public string SolutionName
        {
            get { return solutionName; }
        }

        public List<Task> Tasks
        {
            get { return tasks; }
        }

        public StudentTasksManager(string path,  KeyManager keyManager)
        {
            this.path = path;
            solutionName = path.Substring(path.Length - 11, 11);
            this.keyManager = keyManager;
        }

        public string ShowTasks()
        {
            string result = "\n";
            for (int i = 0; i < tasks.Count; i++)
            {
                result += tasks[i].ToString() + "\n";
            }
            return result;
        }

        private void AddTask(Task task)
        {
            if (maxTestsCount < task.Tests.Count)
                maxTestsCount = task.Tests.Count;
            tasks.Add(task);
        }

        public void AnalyzeTasks()
        {
            foreach(DeclaredTask declaredTask in keyManager.DeclaredTasks)
            {
                string taskPath = path + $@"\{declaredTask.NameOfTask}.pl";
                string taskName = declaredTask.NameOfTask;
                Task task = new Task(taskPath, taskName);
                task.GetBasicInformations();
                task.AnalyzeTests(declaredTask.DeclaredTests);
                AddTask(task);
            }
        }

        public override string ToString()
        {
            return SolutionName;
        }

    }
}
