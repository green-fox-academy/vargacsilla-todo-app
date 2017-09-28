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
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
            }
            else if (args.Contains("-l"))
            {
                ListTasks();
            }
            else if (args.Contains("-a"))
            {
                AddNewTask(args);
            }
            else if (args.Contains("-r"))
            {
                RemoveNthTask(args[1]);
            }
            else
            {
                Console.WriteLine("\nUnsupported argument. Try the following:");
                PrintCommands();
            }
            Console.ReadLine();
        }

        private static void RemoveNthTask(string nth)                         // should it have an int az input parameter? it would make more sense - DEMO material?
        {
            string path = @"../../../../tasks.txt";
            string[] content = File.ReadAllLines(path);

            if (content.Length >= 2)
            {
                int index;                                                              
                int.TryParse(nth, out index);                                  // simple Parse might be enough -- or use the bool it gives
                List<string> newTaskList = content.ToList();
                newTaskList.RemoveAt(index - 1);                                // if var is called index, it should be index, not index+1...

                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var newTask in newTaskList)
                    {
                        writer.WriteLine(newTask);
                    }
                }
            }
        }

        private static void AddNewTask(string[] newTask)
        {
            if (newTask.Length == 1)
            {
                Console.WriteLine("Unable to add: no task provided.");
            }
            else
            {
                string path = @"../../../../tasks.txt";                                 // source .txt file could go up?
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(newTask[1]);
                }
            }
        }

        private static void ListTasks()
        {
           string path = @"../../../../tasks.txt";
            try
            {
                string[] content = File.ReadAllLines(path);
                if (content.Length == 0)
                {
                    Console.WriteLine("No todos for today! :)");
                }
                else
                {
                    for (int i = 0; i < content.Length; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, content[i]);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Uh-oh, could not read the file!");
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
