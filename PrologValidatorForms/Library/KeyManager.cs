using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms.Library
{
    class KeyManager
    {
        string keyFilePath;
        List<DeclaredTask> declaredTasks = new List<DeclaredTask>();

        public KeyManager(string keyFilePath)
        {
            this.keyFilePath = keyFilePath;
        }

        public void AnalyzeKeyFile()
        {
            StreamReader sr = new StreamReader(keyFilePath);
            string currentLine = "";

            while ((currentLine = sr.ReadLine()) != null)
            {
                if(InputValidator.ValidateTaskName(currentLine))
                {
                    DeclaredTask dt = new DeclaredTask(currentLine);
                    declaredTasks.Add(dt);
                }
                else
                {

                }
            }
        }

        private void AddTestToLastTask(string currentLine)
        {

        }

        class DeclaredTask
        {
            string nameOfTask;
            List<string> declaretedTests = new List<string>();

            public DeclaredTask(string nameOfTask)
            {
                this.nameOfTask = nameOfTask;
            }
        }

    }
}
