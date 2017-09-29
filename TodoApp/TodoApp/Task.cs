using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    class Task
    {
        public string description;
        public bool isComplete;
        string checkbox = "[ ] ";
        string checkboxDone = "[x] ";

        public void CreateTask(string description)
        {
            this.description = description;
            isComplete = false;
        }

        public string PrintTask()
        {
            if (isComplete)
            {
                checkbox = checkboxDone;
            }
            return string.Concat(checkbox, description);
            //Console.WriteLine(checkbox, description);

        }
    }
}
