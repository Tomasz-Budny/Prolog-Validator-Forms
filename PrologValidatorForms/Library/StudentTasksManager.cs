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

    /// <summary>
    /// Klasa
    /// </summary>
    /// <param name="studentDirectoryPath">Przechowywuje </param>
    /// <param name="solutionName">Przechowywuje </param>
    /// <param name="solutionName">Przechowywuje </param>
    /// <param name="maxTestsCount">Przechowywuje </param>
    /// <param name="keyManager">Przechowywuje </param>
    /// <param name="types">Lista przechowująca obiekty typu PathListTypes</param>
    partial class StudentTasksManager
    {
        string studentDirectoryPath;
        string solutionName;
        int maxTestsCount;
        KeyManager keyManager;
        List<Task> tasks = new List<Task>();

        public int MaxTestCount { get => maxTestsCount;  }
        public string SolutionName { get => solutionName; }
        public List<Task> Tasks { get => tasks; }

        /// <summary>
        /// Konstruktor kopiujący inicializujący wszystkie pola składowej klasy
        /// </summary>
        /// <param name="studentDirectoryPath">Przechowywuje ścieżkę w której znajduje się grupa</param>
        /// <param name="keyManager"></param>
        public StudentTasksManager(string studentDirectoryPath,  KeyManager keyManager)
        {
            this.studentDirectoryPath = studentDirectoryPath;
            solutionName = studentDirectoryPath.Substring(studentDirectoryPath.Length - 11, 11);
            this.keyManager = keyManager;
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <returns></returns>
        public string ShowTasks()
        {
            string result = "\n";
            for (int i = 0; i < tasks.Count; i++)
            {
                result += tasks[i].ToString() + "\n";
            }
            return result;
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="task"></param>
        private void AddTask(Task task)
        {
            if (maxTestsCount < task.Tests.Count)
                maxTestsCount = task.Tests.Count;
            tasks.Add(task);
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        public void AnalyzeTasks()
        {
            foreach(DeclaredTask declaredTask in keyManager.DeclaredTasks)
            {
                string taskPath = studentDirectoryPath + $@"\{declaredTask.NameOfTask}.pl";
                string taskName = declaredTask.NameOfTask;
                Task task = new Task(taskPath, taskName);
                task.GetBasicInformations();
                task.AnalyzeTests(declaredTask.DeclaredTests);
                AddTask(task);
            }
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SolutionName;
        }

    }
}
