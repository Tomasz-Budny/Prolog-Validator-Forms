using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Prolog;
using PrologValidatorForms.Library;

namespace PrologValidatorForms
{
    /// <summary>
    /// Klasa odpowiedzialna za aktywowanie programu.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Metoda uruchamiająca działanie aplikacji.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new Main());            
        }
    }
}
