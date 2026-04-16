using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    protected override string GetActivityName()
    {
        return "Swimming";
    }

    public override double GetDistance()
    {
        return (_laps * 50 / 1000.0) * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}
