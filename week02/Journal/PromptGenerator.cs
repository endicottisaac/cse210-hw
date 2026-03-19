using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "How did I make progress towards my goals today?",
        "How did I see the hand of the Lord in my life today?",
        "What is one thing I am grateful for today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small win I had today?",
        "What is the best thing I ate today?",
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        return _prompts[index];
    }
}
