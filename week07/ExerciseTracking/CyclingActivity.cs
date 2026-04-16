using System;

public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    protected override string GetActivityName()
    {
        return "Cycling";
    }

    public override double GetDistance()
    {
        return (_speed / 60) * GetLengthInMinutes();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
