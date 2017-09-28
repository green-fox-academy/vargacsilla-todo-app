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
            else
            {
                Console.WriteLine("Unsupported argument. Try the following:");
                PrintCommands();
            }
            Console.ReadLine();
        }

        private static void AddNewTask(string[] newTask)
        {
                string path = @"../../../../tasks.txt";                                 // source .txt file could go up?
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(newTask[1]);
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
