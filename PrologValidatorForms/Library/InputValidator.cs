using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PrologValidatorForms
{
    /// <summary>
    /// Klasa która przetrzymuje paterny nazw i posiada metody je sprawdzające
    /// </summary>
    /// <param name="studentDirectoryPattern">Przechowywuje patern nazwy studenta</param>
    /// <param name="taskNamePattern">Przechowywuje patern nazwy zadania</param>
    /// <param name="groupDirectoryPattern">Przechowywuje patern nazwy grupy studentów</param>
    static class InputValidator
    {
        private static Regex studentDirectoryPattern = new Regex("^K[1-9]_[0-9]{6}_[1-9]$");
        private static Regex taskNamePattern = new Regex("^[z|Z]ad[0-9]{1,2}$");
        private static Regex groupDirectoryPattern= new Regex("^G[1-9]_[0-9]{4}$");

        // GK_XXXX
        // K - numer grupy
        // XXXX - rocznik


        /// <summary>
        /// Metoda stpawdzająca poprawność nazwy studenta z paternem
        /// </summary>
        /// <param name="path">Przechowywuje ścieżkę do studenta</param>
        /// <returns>Zwraca informację czy nazwa studenta jest zgodna z paternem</returns>
        public static bool ValidateStudentDirectory(string path)
        {
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return studentDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        /// <summary>
        /// Metoda stpawdzająca poprawność nazwy grupy studentów z paternem
        /// </summary>
        /// <param name="path">Przechowywuje ścieżkę do grupy studentów</param>
        /// <returns>Zwraca informację czy nazwa grupy studentów jest zgodna z paternem</returns>
        public static bool ValidateGroupDirectory(string path)
        {
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return groupDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        /// <summary>
        /// Metoda stpawdzająca poprawność nazwy zadania z paternem
        /// </summary>
        /// <param name="path">Przechowywuje ścieżkę do zadania</param>
        /// <returns>Zwraca informację czy nazwa zadania jest zgodna z paternem</returns>
        public static bool ValidateTaskName(string name)
        {
            return taskNamePattern.IsMatch(name);
        }
    }
}
