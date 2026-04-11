using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity Portion:
        // added a simple activity log to track activities completed per session
        // added checks to make sure we don't repeat prompts and questions until they've all been used

        ActivityLog log = new ActivityLog();
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                log.RecordActivity("Breathing");
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                log.RecordActivity("Reflecting");
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                log.RecordActivity("Listing");
            }
            else if (choice == "4")
            {
                log.DisplayLog();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
