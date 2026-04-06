using System;
using System.Collections.Generic;


//creativity portion
//has multiple scriptures stored to memorize and choose from
//you can also hit enter to get one randomly

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>();

        Reference ref1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(ref1, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");
        scriptureLibrary.Add(scripture1);
        
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(ref2, "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths");
        scriptureLibrary.Add(scripture2);
        
        Reference ref3 = new Reference("1 Nephi", 3, 7);
        Scripture scripture3 = new Scripture(ref3, "And it came to pass that I Nephi said unto my father I will go and do the things which the Lord hath commanded for I know that the Lord giveth no commandments unto the children of men save he shall prepare a way for them that they may accomplish the thing which he commandeth them");
        scriptureLibrary.Add(scripture3);
        
        Reference ref4 = new Reference("Philippians", 4, 13);
        Scripture scripture4 = new Scripture(ref4, "I can do all things through Christ which strengtheneth me");
        scriptureLibrary.Add(scripture4);

        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("\nAvailable Scriptures:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.WriteLine("3. 1 Nephi 3:7");
        Console.WriteLine("4. Philippians 4:13");
        Console.WriteLine("5. Random Selection");
        Console.Write("\nSelect a scripture (1-5): ");
        
        string choice = Console.ReadLine();
        Scripture selectedScripture;
        
        if (choice == "5")
        {
            Random random = new Random();
            int randomIndex = random.Next(scriptureLibrary.Count);
            selectedScripture = scriptureLibrary[randomIndex];
        }
        else if (int.TryParse(choice, out int index) && index >= 1 && index <= 4)
        {
            selectedScripture = scriptureLibrary[index - 1];
        }
        else
        {
            selectedScripture = scriptureLibrary[0];
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Great job memorizing!");
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}