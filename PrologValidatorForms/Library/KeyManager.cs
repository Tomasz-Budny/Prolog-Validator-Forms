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
    /// <param name="keyFilePath">Przechowywyje ścieżkę klucza</param>
    /// <param name="declaredTasks">Lista przechowująca obiekty typu DeclaredTask</param>
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

        /// <summary>
        /// Metoda zwracająca declaredTasks
        /// </summary>
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
    /// Klasa przetrzymująca zapytania do danego zadania
    /// </summary>
    /// <param name="nameOfTask">Przechowywyje nazwę obiektu z zapytaniami do danego zadania</param>
    /// <param name="declaredTests">Lista przechowująca obiekty typu string</param>
    class DeclaredTask
    {
        string nameOfTask;
        List<string> declaredTests = new List<string>();

        /// <summary>
        /// Metoda zwracająca declaredTests
        /// </summary>
        public List<string> DeclaredTests => declaredTests;

        /// <summary>
        /// Metoda zwracająca nameOfTask
        /// </summary>
        public string NameOfTask => nameOfTask;

        /// <summary>
        /// Metoda dodająca zapytanie do listy zapytań
        /// </summary>
        /// <param name="testContent">Przetrzymuje treść zapytania</param>
        public void AddTest(string testContent)
        {
            declaredTests.Add(testContent);
        }

        /// <summary>
        /// Konstruktor kopiujący inicializujący wszystkie pola składowej klasy
        /// </summary>
        /// <param name="nameOfTask">Przechowywyje nazwę obiektu z zapytaniami do danego zadania</param>
        public DeclaredTask(string nameOfTask)
        {
            this.nameOfTask = nameOfTask;
        }
    }
}
