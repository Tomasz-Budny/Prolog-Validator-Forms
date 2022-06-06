using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms.Library
{
    static class SizeConverter
    {
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
