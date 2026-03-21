using System;
using System.Collections.Generic;

namespace to_do_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("To-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":

                        Console.Write("Enter task: ");

                        string task = Console.ReadLine();

                        if (task != "")
                        {
                            tasks.Add(task);

                            Console.WriteLine("Task added!");
                        }
                        else
                        {
                            Console.WriteLine("Task cannot be empty");
                        }

                        break;

                    case "2":

                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Task list is empty");
                        }
                        else
                        {
                            Console.WriteLine("Tasks:");

                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine((i + 1) + ". " + tasks[i]);
                            }
                        }

                        break;

                    case "3":

                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove");
                            break;
                        }

                        Console.Write("Enter task number to remove: ");

                        int number;

                        bool valid = int.TryParse(Console.ReadLine(), out number);

                        if (valid)
                        {
                            if (number >= 1 && number <= tasks.Count)
                            {
                                string removedTask = tasks[number - 1];

                                tasks.RemoveAt(number - 1);

                                Console.WriteLine("Removed: " + removedTask);
                            }
                            else
                            {
                                Console.WriteLine("Invalid task number");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number");
                        }

                        break;

                    case "4":

                        exit = true;

                        Console.WriteLine("Exiting application");

                        break;

                    default:

                        Console.WriteLine("Invalid choice");

                        break;
                }

                Console.WriteLine();
            }
        }
    }
}