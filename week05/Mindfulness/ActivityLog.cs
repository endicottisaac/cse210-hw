using System;

public class ActivityLog
{
    private int _breathingCount;
    private int _reflectingCount;
    private int _listingCount;

    public ActivityLog()
    {
        _breathingCount = 0;
        _reflectingCount = 0;
        _listingCount = 0;
    }

    public void RecordActivity(string activityName)
    {
        if (activityName == "Breathing")
        {
            _breathingCount++;
        }
        else if (activityName == "Reflecting")
        {
            _reflectingCount++;
        }
        else if (activityName == "Listing")
        {
            _listingCount++;
        }
    }

    public void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine();
        Console.WriteLine($"Breathing completed: {_breathingCount}");
        Console.WriteLine($"Reflecting completed: {_reflectingCount}");
        Console.WriteLine($"Listing completed: {_listingCount}");
        Console.WriteLine($"Total activities completed: {GetTotalCount()}");
    }

    public int GetTotalCount()
    {
        return _breathingCount + _reflectingCount + _listingCount;
    }
}
