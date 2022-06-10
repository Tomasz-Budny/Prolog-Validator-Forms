using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrologValidatorForms
{
    enum PathListTypes
    {
        Directory,
        File
    }

    /// <summary>
    /// Klasa przechowywuje ścieżki plików, ich typ oraz zarządza nimi
    /// </summary>
    /// <param name="paths">Lista przechowywująca ścieżki do plików lub folderów</param>
    /// <param name="types">Lista przechowująca typy powyższych ścieżek</param>
    class PathsManager
    {
        List<string> paths = new List<string>();
        List<PathListTypes> types = new List<PathListTypes>();

        /// <summary>
        /// Metoda dodająca ścieżki i typy do odpowiednich list
        /// </summary>
        /// <param name="path">Przechowywuje ścieżkę</param>
        /// <param name="type">Przechowywuje typ powyższej ścierzki</param>
        public void Add(string path, PathListTypes type)
        {
            paths.Add(path);
            types.Add(type);
        }

        /// <summary>
        /// Metoda czyszcząca listy
        /// </summary>
        public void Clear()
        {
            paths.Clear(); types.Clear();
        }

        /// <summary>
        /// Metoda zwracająca ścieżkę o podanym indeksie
        /// </summary>
        /// <param name="index">Przechowywuje indeks</param>
        /// <returns>Zwraca ścieżkę o podanym indeksie</returns>
        public string GetPath(int index)
        {
            return paths[index];
        }

        /// <summary>
        /// Metoda zwracająca typ pliku o danym indeksie
        /// </summary>
        /// <param name="index">Przechowywuje indeks</param>
        /// <returns>Zwraca typ pliku o danym indeksie</returns>
        public PathListTypes GetPathType(int index)
        {
            return types[index];
        }
    }
}
