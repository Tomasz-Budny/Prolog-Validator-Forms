using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PrologValidatorForms
{
    static class InputValidator
    {
        private static Regex directoryPattern = new Regex("^K[1-9]_[0-9]{6}_[1-9]$");
        private static Regex taskNamePattern = new Regex("^[z|Z]ad[0-9]{1,2}$");

        public static bool ValidateDirectory(string path)
        {
            if (path.Length < 11)
                return false;
            string endPath = path.Substring(path.Length - 11, 11);
            Console.WriteLine(endPath);
            return directoryPattern.IsMatch(endPath);
        }

        public static bool ValidateTaskName(string name)
        {
            return taskNamePattern.IsMatch(name);
        }
    }
}
