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
        //static string path = @"../../../../tasks.txt";
        //static string[] fileContent = File.ReadAllLines(path);

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
                todoList.AddNewTask(args[1]);
            }
            else if (args.Contains("-r"))
            {
                todoList.RemoveNthTask(args[1]);
            }
            else if (args.Contains("-c"))
            {
                todoList.CheckTask(args[1]);
            }
            else
            {
                Console.WriteLine("Unsupported argument. Try the following:");
                PrintCommands();
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
