using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PrologValidatorForms
{
    static class InputValidator
    {
        private static Regex studentDirectoryPattern = new Regex("^K[1-9]_[0-9]{6}_[1-9]$");
        private static Regex taskNamePattern = new Regex("^[z|Z]ad[0-9]{1,2}$");
        private static Regex groupDirectoryPattern= new Regex("^G[1-9]_[0-9]{4}$");
        
        // GK_XXXX
        // K - numer grupy
        // XXXX - rocznik
        
        public static bool ValidateStudentDirectory(string path)
        {
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return studentDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        public static bool ValidateGroupDirectory(string path)
        {
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return groupDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        public static bool ValidateTaskName(string name)
        {
            return taskNamePattern.IsMatch(name);
        }
    }
}
