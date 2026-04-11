using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<int> _usedPromptIndexes;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPromptIndexes = new List<int>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    public string GetRandomPrompt()
    {
        int index = GetUnusedPromptIndex();
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item != "")
            {
                items.Add(item);
            }
        }

        return items;
    }

    private int GetUnusedPromptIndex()
    {
        if (_usedPromptIndexes.Count >= _prompts.Count)
        {
            _usedPromptIndexes.Clear();
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);

        while (_usedPromptIndexes.Contains(index))
        {
            index = random.Next(_prompts.Count);
        }

        _usedPromptIndexes.Add(index);
        return index;
    }
}
