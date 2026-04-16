using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    protected string GetShortName()
    {
        return _shortName;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    public virtual string GetDetailsString()
    {
        string status = "[ ]";

        if (IsComplete())
        {
            status = "[X]";
        }

        return $"{status} {_shortName} ({_description})";
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
}
