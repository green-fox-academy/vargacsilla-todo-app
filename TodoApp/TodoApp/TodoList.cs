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
        string[] fileContent = File.ReadAllLines(path);
        //char undone = '-';
        //char done = '+';

        public void ListTasks()
        {
            try
            {
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
            catch (Exception)
            {
                Console.WriteLine("File not found.");
            }
        }

        public void AddNewTask(string newTask)
        {
            if (newTask.Length == 1)
            {
                Console.WriteLine("Unable to add: no task provided.");
            }
            else
            {
                taskList.Add(new Task());
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("-" + newTask);
                }
            }
        }

        public void RemoveNthTask(string stringNth)                         // should it have an int az input parameter? it would make more sense - DEMO material?
        {
            int nth;
            int.TryParse(stringNth, out nth);

            if (fileContent.Length >= 2 && nth <= fileContent.Length)
            {
                List<string> newTaskList = fileContent.ToList();
                newTaskList.RemoveAt(nth - 1);                                // if var is called index, it should be index, not index+1...

                File.WriteAllLines(path, newTaskList);
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
        }

        public void CheckTask(string nth)
        {
            int index = int.Parse(nth);
            //int.TryParse(nth, out index);

            if (fileContent[index - 1][0] == '-')
            {
                fileContent[index - 1] = string.Concat("+", fileContent[index - 1].Substring(1));
                File.WriteAllLines(path, fileContent);
            }
            else
            {
                Console.WriteLine("Task list is too short.");
            }
        }

        //public void CheckTask(string stringNth)
        //{
        //    int nth;
        //    int.TryParse(stringNth, out nth);

        //    try
        //    {
        //        for (int i = 0; i < fileContent.Length; i++)
        //        {
        //            taskList.Add(new Task());
        //            taskList[i].description = fileContent[i].Substring(1);
        //        }

        //        taskList[nth-1].isComplete = true;

        //        string[] taskArray = new string[taskList.Count];

        //        for (int i = 0; i < taskList.Count; i++)
        //        {
        //            if (taskList[i].isComplete)
        //            {
        //                taskArray[i] = "-" + taskList[i].description;
        //            }
        //            else
        //            {
        //                taskArray[i] = "+" + taskList[i].description;
        //            }
        //        }
        //        File.WriteAllLines(path, taskArray);
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("File not found.");
        //    }
        //}
    }
}
