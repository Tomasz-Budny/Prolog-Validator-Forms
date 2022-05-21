using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrologValidatorForms.Library
{
    class GroupManager
    {
        string dirPath;
        string name;
        string destDir;
        Label infoLabel;
        List<ValSolution> vss = new List<ValSolution>();

        public GroupManager(string dirPath, string name, string destDir, Label infoLabel)
        {
            this.dirPath = dirPath;
            this.name = name;
            this.destDir = destDir;
        }

        public void AnalyzeSolution()
        {
            foreach (string dir in Directory.GetDirectories(dirPath))
            {
                if(InputValidator.ValidateStudentDirectory(dir)==true)
                {
                    ValSolution vs = new ValSolution(dir, infoLabel, destDir);
                    vs.AnalyzeSolution();
                    this.vss.Add(vs);
                }
            }
        }
    }
}
