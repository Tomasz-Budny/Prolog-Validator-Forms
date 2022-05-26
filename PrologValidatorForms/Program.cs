using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Prolog;
using PrologValidatorForms.Library;

namespace PrologValidatorForms
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Do zrobienia:

            // ujednolicić odczytywanie plików (aby niezależnie od separatora i systemu można było uruchomić program)
            // przetestować błędy wynikające z systemu zapisu i odczytu - zobaczyć czy nigdzie nie brakuje instrukcji try-catch
            // przetestować i upewnić sie co do poprawności działania interpretera prologa
            // poszukać błędów, zrobić reformat
            // usprawnić interfejs
            //      - dodać customową ikonę
            //      - zmienić ikony na customowe
            //      - sprawić aby każdy browser pokazywał tylko pliki którymi się zajmuje
            //      - zmniejszyć okna albo przearanżować trochę cały interfejs
            //      - dodać przycisk odpowiedzialny za zapisywanie pliku
            //      - dodać checkbox sprawdzający czy chcemy otworzyć odrazu excela
            //      - dodać konsole wyświetlającą stan analizy każdego zaadania (jak w pierwotnej wersji programu)
            //      - pomniejszyć file browsery i w efekcie cały interfejs
            // Zmienić kolumnę rozmiar w bajtach na "Rozmiar" tak aby pokazywała jednostkę w jakiej jest zapisany plik
            // pomyśleć nad oddzieleniem przycisku zatwierdź od przycisku eksportującego xlsx. (w takim przypadku dodać pole ValSolution do programu)
            // dodać kolumnę z procentowym udziałem zaliczonych testów
            // 

            // Dodać nową warstwę przechowującą grupy a w niej pliku poszczególnych uczniów (obudowaywałaby ona klasę valSolution)
            // Zmienić wygląd Excela


            //                           PODZIAŁ PRAC

            // Paweł Kowalczyk - konwersja baitów na odpowiednie jednostki
            // Grupa GUI - zmiana gui, dodanie ignorowania nieistotnych plików (w przypadku pierwszego eksploratora tylko txt i pl w przypadku drugiego xslt i csv)
            // Grupa IO - zmiana excela dodanie nowych arkuszy
            // Ja i Michał - jak zmieni się koncepcja na ocenianie całej grupy, to my jo

            // X - logo aplikacji, logo ikonek (folderów, plików tekstowych, plików .pl, .xslt itd)


            string keyFilePath = @"C:\Users\tomek\OneDrive\Pulpit\Testy\klucz.txt";
            KeyManager km = new KeyManager(keyFilePath);
            km.AnalyzeKeyFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            
        }
    }
}
