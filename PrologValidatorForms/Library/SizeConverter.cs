using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms.Library
{
    /// <summary>
    /// Klasa konwertująca rozmiar pliku
    /// </summary>
    static class SizeConverter
    {
        /// <summary>
        /// Klasa zamieniająca rozmiar pliku (np. z kB na MB)
        /// </summary>
        /// <param name="fileSizeInBytes">Przechowywuje rozmiar pliku w baitach</param>
        /// <returns>Zwraca zmieniony rozmiar pliku</returns>
        public static string ConvertSize(long fileSizeInBytes)
        {
            int prefix = 0;
            double fileSizeInBytesConvertedToDouble = (double)fileSizeInBytes;
            while (fileSizeInBytesConvertedToDouble > 1024)
            {
                fileSizeInBytesConvertedToDouble /= 1024;
                prefix++;
            }
            double roundedFileSize = Math.Round(fileSizeInBytesConvertedToDouble, 1);
            string convertedFileSize = roundedFileSize.ToString() + $" {(Prefixes)prefix}";
            return convertedFileSize;
        }
    }
}
