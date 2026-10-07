using System;

namespace EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== ETERNAL QUEST =====");
            Console.WriteLine($"Your score: {manager.Score}");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.RecordGoalEvent();
                    break;

                case "4":
                    manager.SaveGoals("goals.txt");
                    break;

                case "5":
                    manager.LoadGoals("goals.txt");
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Keep working toward your goals!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

