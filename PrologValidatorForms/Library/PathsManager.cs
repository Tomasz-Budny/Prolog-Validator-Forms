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
    /// Klasa
    /// </summary>
    /// <param name="paths">Lista przechowująca obiekty typu string</param>
    /// <param name="types">Lista przechowująca obiekty typu PathListTypes</param>
    class PathsManager
    {
        List<string> paths = new List<string>();
        List<PathListTypes> types = new List<PathListTypes>();

        /// <summary>
        /// Metoda
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public void Add(string path, PathListTypes type)
        {
            paths.Add(path);
            types.Add(type);
        }

        /// <summary>
        /// Metoda
        /// </summary>
        public void Clear()
        {
            paths.Clear(); types.Clear();
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetPath(int index)
        {
            return paths[index];
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PathListTypes GetPathType(int index)
        {
            return types[index];
        }
    }
}
