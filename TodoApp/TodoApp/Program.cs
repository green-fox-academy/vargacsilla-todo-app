using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TodoApp
{
    class Program
    {
        static string path = @"../../../../tasks.txt";
        static string[] fileContent = File.ReadAllLines(path);
        static string done = "[x]";

        static void Main(string[] args)
        {
            var todoList = new TodoList();

            if (args.Length == 0)
            {
                PrintUsage();
            }

            else if (args.Contains("-l"))                                           // enum ?
            {
                todoList.ListTasks();
            }
            else if (args.Contains("-a"))
            {
                AddNewTask(args);
            }
            else if (args.Contains("-r"))
            {
                RemoveNthTask(args[1]);
            }
            else if (args.Contains("-c"))
            {
                CheckTask(args[1]);
            }
            else
            {
                Console.WriteLine("Unsupported argument. Try the following:");
                PrintCommands();
            }
            Console.ReadLine();
        }

        private static void CheckTask(string nth)
        {
            int index = int.Parse(nth);
            //int.TryParse(nth, out index);
            
            if (fileContent[index-1].Substring(0, 2) != "[x]")
            {
                fileContent[index - 1] = string.Concat(done, fileContent[index - 1].Substring(3));
                File.WriteAllLines(path, fileContent);
            }
            else
            {
                Console.WriteLine("Task list is too short.");            
            }
        }

        private static void RemoveNthTask(string nth)                         // should it have an int az input parameter? it would make more sense - DEMO material?
        {
            if (fileContent.Length >= 2)
            {
                int index;                                                              
                int.TryParse(nth, out index);                                  // simple Parse might be enough -- or use the bool it gives
                List<string> newTaskList = fileContent.ToList();
                newTaskList.RemoveAt(index - 1);                                // if var is called index, it should be index, not index+1...

                File.WriteAllLines(path, newTaskList);
            }
        }

        private static void AddNewTask(string[] newTask)
        {
            //var task = new Task(newTask[1]);

            if (newTask.Length == 1)
            {
                Console.WriteLine("Unable to add: no task provided.");
            }
            else
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("[ ] " + newTask[1]);
                }
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Command Line Todo application \n=============================\n\nCommand line arguments:");
            PrintCommands();

        }

        private static void PrintCommands()
        {
            Console.WriteLine("-l   Lists all the tasks");
            Console.WriteLine("-a   Adds a new task");
            Console.WriteLine("-r   Removes a task");
            Console.WriteLine("-c   Completes a task");
        }
    }
}
