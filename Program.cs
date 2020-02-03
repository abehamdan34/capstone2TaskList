using System;
using System.Collections.Generic;

namespace CapStone2TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UserTask> workTaskList = new List<UserTask>
            {
                new UserTask("James", "Figures out how to use discord", new DateTime(2020, 10, 12)),
            };

            int userInput = 0;
            while (true)
            {
                //display the task manager options
                Console.WriteLine("Welcome to the task manager!\n 1. List tasks\n 2. Add task \n 3. Delete task \n 4. Mark task complete \n 5. List tasks before specific due date \n 6. Quit");

                //taking in the users choice 
                try
                {
                    userInput = int.Parse(GetUserInput("Please enter 1-5 to choose one of the options!"));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                if (userInput == 1)
                {
                    DisplayInfo(workTaskList);
                }
                else if (userInput == 2)
                {
                    AddUserInputToList(workTaskList, "ADD TASK");
                }
                else if (userInput == 3)
                {
                    DeleteTask(workTaskList);
                }
                else if (userInput == 4)
                {
                    MarkTaskComplete(workTaskList);
                }
                else if (userInput == 5)
                {
                    DisplayBeforeDueDate(workTaskList);
                }
                else
                {
                    Console.WriteLine("This option does not exist, please choose a new option.");
                }
            }
        }


        //adding the users input into the list according to where they need to go.
        public static void AddUserInputToList(List<UserTask> workTaskList, string message)
        {
            Console.WriteLine(message);

            UserTask newTask = new UserTask();

            Console.Write("Team Member Name: ");
            newTask.Name = Console.ReadLine();

            Console.Write("Task Description: ");
            newTask.TaskDescription = Console.ReadLine();

            while (true)
            {
                Console.Write("Due Date (format: mm/dd/yyyy): ");
                try
                {
                    newTask.DueDate = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date, please try again. Format: mm/dd/yyyy");
                }
            }

            // this is defaulted in the constructor
            //newTask.Completion = false;

            workTaskList.Add(newTask);
            Console.WriteLine("Task has been entered.");

        }

        //userinput method
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        //Display all the tasks and ask the user which one they want to delete deciding by number 1 - whatever. 
        //Validate the input making sure its withing range. Display the task they choose and ask if theyre SURE they want to Delete it. if Y remove it if N go back to main menu.
        public static void RemoveUserInputFromList(List<UserTask> workTaskList, string message)
        {

        }
        //display all the tasks have them numbered starting at 1 
        public static void DisplayInfo(List<UserTask> taskInfo)
        {
            //using a lambda captures the items in the list and displays them.
            int i = 0;
            taskInfo.ForEach(task =>
            {
                i++;
                Console.WriteLine($"\n{i}. {task.ToString()}\n");
            });

            //for (int i = 0; i < taskInfo.Count; i++)
            //{
            //    Console.WriteLine(taskInfo[i].ToString());
            //Console.WriteLine($"{taskInfo[i].WorkerName}");
            //Console.WriteLine($"{taskInfo[i].DueDate}");
            //Console.WriteLine($"{taskInfo[i].Completion}");
            //Console.WriteLine($"{taskInfo[i].TaskDescription}");

            //}
        }

        public static void DeleteTask(List<UserTask> taskInfo)
        {
            DisplayInfo(taskInfo);
            Console.WriteLine("Which one would you like to delete? ");
            int input = 0;
            char choice = ' ';
            while (true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (taskInfo[(input - 1)] != null)
                    {
                        Console.WriteLine("Are you sure you want to delete this task (y/n)? ");
                    }
                    choice = char.Parse(Console.ReadLine());
                    if (choice == 'y')
                    {
                        taskInfo.Remove(taskInfo[input - 1]);
                        Console.WriteLine("Task has been deleted.");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                    // index out of range didnt work for lists, so we used argument out of range instead.
                    else if (ex is ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("This task does not exist, choose another.");
                    }
                }
            }
        }
        public static void MarkTaskComplete(List<UserTask> taskInfo)
        {
            DisplayInfo(taskInfo);
            Console.WriteLine("Which one would you like to mark as complete? ");
            int input = 0;
            char choice = ' ';
            while (true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (taskInfo[(input - 1)] != null)
                    {
                        Console.WriteLine("Are you sure you want to mark this task as complete (y/n)? ");
                    }
                    choice = char.Parse(Console.ReadLine());
                    if (choice == 'y')
                    {
                        taskInfo[input - 1].CompleteTask();
                        Console.WriteLine("Task has been marked complete.");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                    // index out of range didnt work for lists, so we used argument out of range instead.
                    else if (ex is ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("This task does not exist, choose another.");
                    }
                }
            }
        }

        public static void DisplayBeforeDueDate(List<UserTask> taskInfo)
        {
            bool isTaskBeforeDate = false;
            Console.WriteLine("Please input a due date (format: mm/dd/yyyy): ");
            DateTime date = DateTime.Now;
            while (true)
            {
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date, please try again.");
                }
            }
            taskInfo.ForEach(task =>
            {
                int i = 0;
                int result = DateTime.Compare(task.DueDate, date);
                if (result < 0)
                {
                    i++;
                    Console.WriteLine($"\n{i}. {task.ToString()}\n");
                    isTaskBeforeDate = true;
                }
            });

            if (!isTaskBeforeDate)
            {
                Console.WriteLine("There are no tasks before that due date.");
            }
        }
    }
}
