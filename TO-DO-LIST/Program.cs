using System;
using System.Reflection.Metadata.Ecma335;


namespace TODOLIST
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<string> tasks = new List<string>();
            string choice;

            

            do
            {
                MainMenu();
                choice = GetInt(1);
                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        RemoveTask(tasks);
                        break;
                    case "3":
                        ShowTasks(tasks);
                        break;
                    case "4":
                        Console.WriteLine("Goodbye 👋");
                        return;
                    default:
                        Console.WriteLine("something went wrong");
                        break;
                }
            }
            while (choice != "4");

            Console.ReadKey();
        }

        //🌠the main menu
        static void MainMenu()
        {
            
            TypeText("Welcome to your to do list 📋 \n How can I help you?😄");
            TypeText("press:\n1-AddTask📎\n2-RemoveTask🗑️\n3-Showtasks👀\n4-Exit🚪", 10);
            NewLine();
        }

            //📎AddTask
            static void AddTask(List<string> taskName)
            {
                Console.WriteLine("Enter the task: ");
                string task = Console.ReadLine();
                taskName.Add(task);
                TypeText("Task added ✔️",10);
                NewLine();
        }

            //👀Showtasks
            static void ShowTasks(List<string> tasks)
            {
            Console.WriteLine("//// the tasks you have//////////////");
                int i = 1;
            if (tasks.Count == 0)                                        // .count                                  
            {                                                
                Console.WriteLine("No tasks yet 📭");                 
                return;                                               
            }                                                           
            foreach (string task in tasks)
                {
                TypeText($"{i}- {task}",10);
                    i++;
                NewLine2();
            }
            }

        //🗑️RemoveTask
        static void RemoveTask(List<string> taskName)
        {
            if (taskName.Count == 0)
            {
                Console.WriteLine("No tasks to remove 📭");
                NewLine2();
                return;
            }

            ShowTasks(taskName);
            Console.WriteLine("Which task do you want to remove?");

            string input = GetInt(2); // عدد digits بس
            int choice = int.Parse(input); // نحوله int بعد validation

            if (choice < 1 || choice > taskName.Count)
            {
                Console.WriteLine("Invalid Number ⚠️");
                return;
            }

            taskName.RemoveAt(choice - 1);
            Console.WriteLine("Task removed 🗑️");
            NewLine2();
        }


        //input int validation
        static string GetInt(int maxLength)
        {
            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty ⚠️");
                    continue;
                }

                if (input.Length > maxLength)
                {
                    Console.WriteLine($"Max {maxLength} digits only ⚠️");
                    continue;
                }

                bool allDigits = true;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        allDigits = false;
                        break;
                    }
                }

                if (!allDigits)
                {
                    Console.WriteLine("Digits only ⚠️");
                    continue;
                }

                return input;
            }
        }

        //Space Line
        static void NewLine()
        {
            Console.WriteLine("------------------------------------");
        }
        static void NewLine2()
        {
            Console.WriteLine("////////////////////////////////////");
        }

        //💤slow Typing
        static void TypeText(string text, int speed = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
}
















































































