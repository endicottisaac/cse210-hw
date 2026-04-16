using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _lastLevel;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _lastLevel = 1;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
                PauseForUser();
            }
            else if (choice == "3")
            {
                SaveGoals();
                PauseForUser();
            }
            else if (choice == "4")
            {
                LoadGoals();
                PauseForUser();
            }
            else if (choice == "5")
            {
                RecordEvent();
                PauseForUser();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                PauseForUser();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {GetLevel()}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int goalType = GetMenuNumber("Which type of goal would you like to create? ", 1, 3);

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = GetPositiveNumber("What is the amount of points associated with this goal? ");

        if (goalType == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == 3)
        {
            int target = GetPositiveNumber("How many times does this goal need to be accomplished to get the bonus? ");
            int bonus = GetPositiveNumber("How many points is the bonus worth? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully.");
        PauseForUser();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found, lets set some goals. Sooner rather than later.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();

        int goalNumber = GetMenuNumber("Which goal did you accomplish? ", 1, _goals.Count);
        Goal selectedGoal = _goals[goalNumber - 1];
        int pointsEarned = selectedGoal.RecordEvent();

        if (pointsEarned > 0)
        {
            _score += pointsEarned;
            Console.WriteLine($"Congrats! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
            DisplayLevelAchievement();
        }
        else
        {
            Console.WriteLine("That goal is already complete, no new points awarded.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Could not find that file.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("That file is empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);
        _lastLevel = GetLevel();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] firstSplit = lines[i].Split(":");

            if (firstSplit.Length != 2)
            {
                continue;
            }

            string goalType = firstSplit[0];
            string[] parts = firstSplit[1].Split("|");

            if (goalType == "SimpleGoal" && parts.Length == 4)
            {
                _goals.Add(new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3])));
            }
            else if (goalType == "EternalGoal" && parts.Length == 3)
            {
                _goals.Add(new EternalGoal(parts[0], parts[1], int.Parse(parts[2])));
            }
            else if (goalType == "ChecklistGoal" && parts.Length == 6)
            {
                _goals.Add(new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private void DisplayLevelAchievement()
    {
        int currentLevel = GetLevel();

        if (currentLevel > _lastLevel)
        {
            Console.WriteLine($"Great job! You reached Level {currentLevel}!");

            if (currentLevel == 2)
            {
                Console.WriteLine("First time leveling up! Keep up the pace!");
            }
            else if (currentLevel == 3)
            {
                Console.WriteLine("Whew! Already at Level 3! You are a goal achieving master!");
            }
            else if (currentLevel >= 4)
            {
                Console.WriteLine("You are at your peak, keep on cooking!");
            }

            _lastLevel = currentLevel;
        }
    }

    private int GetPositiveNumber(string prompt)
    {
        int number;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a positive whole number.");
        } while (true);
    }

    private int GetMenuNumber(string prompt, int min, int max)
    {
        int number;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number >= min && number <= max)
            {
                return number;
            }

            Console.WriteLine("Please enter a valid menu number.");
        } while (true);
    }

    private void PauseForUser()
    {
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
}
