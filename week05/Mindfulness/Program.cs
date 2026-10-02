using System;

class Program
{
    static int _activitiesCompleted = 0;

    static void Main(string[] args)
    {
        // Creativity / Exceeding Requirements:
        // This program keeps track of how many mindfulness activities
        // the user has completed during the current session.

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Show Activities Completed");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();

                    _activitiesCompleted++;
                    PauseBeforeMenu();
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();

                    _activitiesCompleted++;
                    PauseBeforeMenu();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();

                    _activitiesCompleted++;
                    PauseBeforeMenu();
                    break;

                case "4":
                    Console.WriteLine();
                    Console.WriteLine(
                        $"You have completed {_activitiesCompleted} mindfulness activities during this session.");

                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Returning to the menu...");
        Thread.Sleep(2000);
    }
}