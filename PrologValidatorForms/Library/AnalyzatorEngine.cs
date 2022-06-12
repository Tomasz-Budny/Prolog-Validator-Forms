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
    /// <summary>
    /// Klasa odpowiadająca za analizę wyników poszczególnych plików
    /// </summary>
    /// <param name="sizeOfFile">Przechowywuje rozmiar pliku</param>
    /// <param name="taskFilePath">Przechowywuje ścieżkę do pliku</param>
    /// <param name="taskName">Przechowywuje nazwę pliku który będzie analizowany</param>
    /// <param name="creationDate">Przechowywuje datę utwórzenia pliku</param>
    /// <param name="correctAnswers">Przechowywuje ilość zaliczonych testów</param>
    /// <param name="totalAnswers">Przechowywuje ilość wszystkich testów</param>
    /// <param name="tests">Lista przechowująca obiekty typu Test</param> 
    class Task
    {
        long sizeOfFile;
        string taskFilePath;
        string taskName;
        string creationDate;
        int correctAnswers = 0;
        int totalAnswers = 0;
        List<Test> tests = new List<Test>();

        /// <summary>
        /// Konstruktor kopiujący inicializujący pola klasy
        /// </summary>
        /// <param name="taskFilePath">Przechowywuje ścieżkę do pliku</param>
        /// <param name="taskName">Przechowywuje nazwę pliku który będzie analizowany</param>
        public Task(string taskFilePath, string taskName)
        {
            this.taskFilePath = taskFilePath;
            this.taskName = taskName;
        }

        public List<Test> Tests => tests;
        public long SizeOfFile => sizeOfFile;
        public string TaskName => taskName;
        public string CreationTime => creationDate;
        public int CorrectAnswers => correctAnswers;
        public int TotalAnswers => totalAnswers;

        /// <summary>
        /// Metoda dodająca obiekt typu Test
        /// </summary>
        /// <param name="content">Przechowywuje zapytania</param>
        /// <param name="isCorrect">Przechowywuje informacje czy test został wykonany poprawnie</param>
        private void AddTest(string content, bool isCorrect)
        {
            totalAnswers++;
            if (isCorrect)
                correctAnswers++;
            tests.Add(new Test(content, isCorrect));
        }

        /// <summary>
        /// Metoda odpowiadająca za analizowanie tablicy wyników dla zapytań oznaczonych "$"
        /// </summary>
        /// <param name="e">Przechowywuje obiekt klasy PrologEngine</param>
        /// <param name="current">Przechowywuje zapytanie</param>
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
                    if (v.Type == "namedvar")
                        goto EndOfLoop;
                    if (moreThan1)
                        answer += "+";
                    answer += v.Value;
                    moreThan1 = true;
                }
                
                values.Add(answer);
            EndOfLoop:;
            }

            List<string> compArr = new List<string>();
            for (int i = 2; i < data.Length; i++)
            {
                if(data[i] != "")
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

        /// <summary>
        /// Metoda pobierająca infoemacje o pliku, datę utworzenia i rozmiar pliku
        /// </summary>
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

        /// <summary>
        /// Metoda tworząca metody klasy test zawierajaca informacje o testach oraz ich wyniki
        /// </summary>
        /// <param name="tests">Przechowywuje obiekt typu string z zapytaniami</param>
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

        /// <summary>
        /// Metoda zwtacająca stringa z nazwą zadania, ścieżką do pliku oraz wynikiem testów
        /// </summary>
        /// <param name="tests">Przechowywuje obiekt typu string z zapytaniami</param>
        /// <returns>Zwraca stringa z nazwą zadania, ścieżką do pliku oraz wynikiem testu</returns>
        public override string ToString()
        {
            if (taskFilePath != null)
                return taskName + "   |   " + taskFilePath + "\n" + ShowTests();
            return "";
        }

        /// <summary>
        /// Metoda zwtacająca wyniki testów
        /// </summary>
        /// <returns>Zwraca wyniki testów</returns>
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

    /// <summary>
    /// Klasa zawierająca zapytania oraz wyniki zapytań
    /// </summary>
    /// <param name="content">Przechowywuje zapytania</param>
    /// <param name="isCorrect">Przechowywuje informacje czy test został wykonany poprawnie</param>
    class Test
    {
        string content;
        bool isCorrect;

        public string Content => content;

        /// <summary>
        /// Metoda zwtacająca informację czy test został wykonany poprawnie
        /// </summary>
        /// <returns>Zwraca informację czy test został wykonany poprawnie</returns>
        public int IsCorrect
        {
            get { if (isCorrect) { return 1; } else { return 0; } }
        }

        /// <summary>
        /// Konstruktor kopiujący inicializujący pola klasy
        /// </summary>
        /// <param name="content">Przechowywuje zapytania</param>
        /// <param name="isCorrect">Przechowywuje informacje czy test został wykonany poprawnie</param>
        public Test(string content, bool isCorrect)
        {
            this.content = content;
            this.isCorrect = isCorrect;
        }

        /// <summary>
        /// Metoda zwtacająca zapytanie oraz informacje czy test został wykonany poprawnie 
        /// </summary>
        /// <returns>Zwraca zapytanie oraz informacje czy test został wykonany poprawnie </returns>
        public override string ToString()
        {
            return $"[ {content}   |   {isCorrect} ]";
        }
    }
}
