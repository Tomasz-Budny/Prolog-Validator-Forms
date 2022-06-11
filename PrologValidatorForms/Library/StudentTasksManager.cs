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
    /// Klasa odpowiadająca za analizę zadań dla konkretnego studenta
    /// </summary>
    /// <param name="studentDirectoryPath">Przechowywuje ścieżkę w której znajduje się grupa</param>
    /// <param name="solutionName">Przechowywuje nazwę studenta, jego grupy i numer podejścia</param>
    /// <param name="maxTestsCount">Przechowywuje największą ilość testów przeprowadzanych dla wszystkich zadań</param>
    /// <param name="keyManager">Przechowywuje obiekt typu KeyManager</param>
    /// <param name="types">Lista przechowująca obiekty typu Task</param>
    partial class StudentTasksManager
    {
        string studentDirectoryPath;
        string solutionName;
        int maxTestsCount;
        KeyManager keyManager;
        List<Task> tasks = new List<Task>();

        /// <summary>
        /// Metoda zwracająca największą ilość testów przeprowadzanych dla wszystkich zadań
        /// </summary>
        /// <returns>Zwraca największą ilość testów przeprowadzanych dla wszystkich zadań</returns>
        public int MaxTestCount { get => maxTestsCount;  }

        /// <summary>
        /// Metoda zwracająca nazwę studenta, jego grupy i numer podejścia
        /// </summary>
        /// <returns>Zwraca nazwę studenta, jego grupy i numer podejścia</returns>
        public string SolutionName { get => solutionName; }

        /// <summary>
        /// Metoda zwracająca listę obiektów typu Task
        /// </summary>
        /// <returns>Zwraca listę obiektów typu Task</returns>
        public List<Task> Tasks { get => tasks; }

        /// <summary>
        /// Konstruktor kopiujący inicializujący wszystkie pola składowej klasy
        /// </summary>
        /// <param name="studentDirectoryPath">Przechowywuje ścieżkę w której znajduje się grupa</param>
        /// <param name="keyManager">Przechowywuje obiekt typu KeyManager</param>
        public StudentTasksManager(string studentDirectoryPath,  KeyManager keyManager)
        {
            this.studentDirectoryPath = studentDirectoryPath;
            solutionName = studentDirectoryPath.Substring(studentDirectoryPath.Length - 11, 11);
            this.keyManager = keyManager;
        }

        /// <summary>
        /// Metoda zwracająca nazwę zadania, jego ścieżkę oraz wyniki testów
        /// </summary>
        /// <returns>Zwraca nazwę zadania, jego ścieżkę oraz wyniki testów</returns>
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
        /// Metoda dodająca do listy tasks dodająca obiekt typy Task
        /// </summary>
        /// <param name="task">Przechowywuje obiekt typu Task</param>
        private void AddTask(Task task)
        {
            if (maxTestsCount < task.Tests.Count)
                maxTestsCount = task.Tests.Count;
            tasks.Add(task);
        }

        /// <summary>
        /// Metoda zbierająca podstawowe informacje o pliku oraz zapisuje wyniki zapytań
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
        /// Metoda zwracając anazwę studenta, jego grupy i numer podejścia
        /// </summary>
        /// <returns>Zwraca nazwę studenta, jego grupy i numer podejścia</returns>
        public override string ToString()
        {
            return SolutionName;
        }

    }
}
