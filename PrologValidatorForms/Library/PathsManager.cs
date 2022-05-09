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

    class PathsManager
    {
        List<string> paths = new List<string>();
        List<PathListTypes> types = new List<PathListTypes>();

        public void Add(string path, PathListTypes type)
        {
            paths.Add(path);
            types.Add(type);
        }

        public void Clear()
        {
            paths.Clear(); types.Clear();
        }

        public string GetPath(int index)
        {
            return paths[index];
        }

        public PathListTypes GetPathType(int index)
        {
            return types[index];
        }
    }
}
