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

        public List<DeclaredTask> DeclaredTasks
        {
            get { return declaredTasks; }
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
                    AddTestToLastTask(currentLine);
                }
            }
        }

        private void AddTestToLastTask(string currentLine)
        {
            if (currentLine == "")
                return;

            if(declaredTasks.Count !=0)
            {
                declaredTasks[declaredTasks.Count - 1].AddTest(currentLine);
            }
        }

    }
    class DeclaredTask
    {
        string nameOfTask;
        List<string> declaredTests = new List<string>();

        public List<string> DeclaredTests
        {
            get { return declaredTests; }
        }

        public string NameOfTask
        {
            get { return nameOfTask; }
        }

        public void AddTest(string testContent)
        {
            declaredTests.Add(testContent);
        }

        public DeclaredTask(string nameOfTask)
        {
            this.nameOfTask = nameOfTask;
        }
    }
}
