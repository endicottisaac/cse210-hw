using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _usedPromptIndexes;
    private List<int> _usedQuestionIndexes;

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "What did you learn about yourself through this experience?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "How can you keep this experience in mind in the future?"
        };

        _usedPromptIndexes = new List<int>();
        _usedQuestionIndexes = new List<int>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    public string GetRandomPrompt()
    {
        int index = GetUnusedPromptIndex();
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        int index = GetUnusedQuestionIndex();
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
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

    private int GetUnusedQuestionIndex()
    {
        if (_usedQuestionIndexes.Count >= _questions.Count)
        {
            _usedQuestionIndexes.Clear();
        }

        Random random = new Random();
        int index = random.Next(_questions.Count);

        while (_usedQuestionIndexes.Contains(index))
        {
            index = random.Next(_questions.Count);
        }

        _usedQuestionIndexes.Add(index);
        return index;
    }
}
