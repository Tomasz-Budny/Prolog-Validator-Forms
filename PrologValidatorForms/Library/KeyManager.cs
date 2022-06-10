using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms.Library
{
    /// <summary>
    /// Klasa przetrzymująca informacje dotyczące klucza
    /// </summary>
    class KeyManager
    {
        string keyFilePath;
        List<DeclaredTask> declaredTasks = new List<DeclaredTask>();

        /// <summary>
        /// Konstruktor kopiujący inicializujący wszystkie pola składowej klasy
        /// </summary>
        /// <param name="keyFilePath">Przechowywyje ścieżkę klucza</param>
        public KeyManager(string keyFilePath)
        {
            this.keyFilePath = keyFilePath;
        }

        public List<DeclaredTask> DeclaredTasks => declaredTasks;

        /// <summary>
        /// Metoda zczytująca kolejne linijki z klucza, jeżeli napotka liniję z zadaniem (np. "zad1") tworzy nowy element listy DeclaredTask,
        /// w przeciwnym wypadku dodaje linijkę z zapytaniem do ostatnio dodanego DeclaredTask
        /// </summary>
        public void AnalyzeKeyFile()
        {
            try
            {
                StreamReader sr = new StreamReader(keyFilePath);
                string currentLine = "";

                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (InputValidator.ValidateTaskName(currentLine))
                    {
                        DeclaredTask dt = new DeclaredTask(currentLine);
                        declaredTasks.Add(dt);
                    }
                    else
                    {
                        AddTestToLastTask(currentLine);
                    }
                }
            }
            catch(Exception)
            {

            }
            
        }

        /// <summary>
        /// Metoda dodająca zapytanie do ostatniego DeclaredTask
        /// </summary>
        /// <param name="path">Przechowywuje zawartość aktualnej linijki w kluczu</param>
        private void AddTestToLastTask(string currentLine)
        {
            if (currentLine == "")
                return;

            if(declaredTasks.Count !=0)
            {
                declaredTasks[declaredTasks.Count - 1].AddTest(currentLine);
            }
        }

    }

    /// <summary>
    /// Klasa przetrzymująca 
    /// </summary>
    class DeclaredTask
    {
        string nameOfTask;
        List<string> declaredTests = new List<string>();

        public List<string> DeclaredTests => declaredTests;
        public string NameOfTask => nameOfTask;

        public void AddTest(string testContent)
        {
            declaredTests.Add(testContent);
        }

        public DeclaredTask(string nameOfTask)
        {
            this.nameOfTask = nameOfTask;
        }
    }
}
