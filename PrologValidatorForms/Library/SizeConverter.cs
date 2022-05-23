using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms.Library
{
    static class SizeConverter
    {
        // Metoda klasy statycznej SizeConverter ma konwertować bajty na kilobajty lub megabajty, w zależności
        // od rzędu wielkości. Metoda ma pobierać rozmiar jako long a zwracać jako string z odpowiednik prefiksem kilo lub mega.
        public static string Convert(long num)
        {
            int prefix = 0;
            double numAsDouble = (double)num;
            while (numAsDouble > 1024)
            {
                numAsDouble /= 1024;
                prefix++;
            }
            if (prefix == 0)
            {
                return numAsDouble.ToString() + " kB";
            }
            else if (prefix == 1)
            {
                return numAsDouble.ToString() + " MB";
            }
            else
            {
                return numAsDouble.ToString() + " GB";
            }
        }
    }
}
