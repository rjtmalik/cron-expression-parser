namespace CronEval.Lib;

public interface ITimePartParser
{
    bool IsMatch(TimePart timePart);
    int[] Parse(string timePart);
}

public enum TimePart
{
    Minute,
    Hour,
    DayOfMonth,
    Month,
    DayOfWeek
}
