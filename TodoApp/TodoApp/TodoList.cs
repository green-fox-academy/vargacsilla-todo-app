using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    class TodoList
    {
        static List<Task> taskList = new List<Task>();
        static string path = @"../../../../tasks.txt";

        public void ListTasks()
        {
            string[] fileContent = File.ReadAllLines(path);

            for (int i = 0; i < fileContent.Length; i++)
            {
                taskList.Add(new Task());
                taskList[i].description = fileContent[i].Substring(1);

                if (fileContent[i][0] == '-')
                {
                    taskList[i].isComplete = false;
                }
                else if (fileContent[i][0] == '+')
                {
                    taskList[i].isComplete = true;
                }
            }

            for (int i = 0; i < taskList.Count; i++)
            {

                Console.WriteLine("{0} - {1}", i + 1, taskList[i].PrintTask());
            }
        }
    }
}
