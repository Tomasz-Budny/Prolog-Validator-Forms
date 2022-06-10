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
    /// 
    /// </summary>
    class PathsManager
    {
        List<string> paths = new List<string>();
        List<PathListTypes> types = new List<PathListTypes>();

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
