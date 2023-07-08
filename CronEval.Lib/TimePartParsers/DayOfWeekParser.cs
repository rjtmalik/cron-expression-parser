using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class DayOfWeekParser: TimePartParser, ITimePartParser
{
    public DayOfWeekParser()
        : base(0, 6) { }

    public bool IsMatch(TimePart timePart)
    {
        return TimePart.DayOfWeek == timePart;
    }

    public override int[] Parse(string timePart)
    {
        try
        {
            return base.Parse(timePart);
        }
        catch(TimePartParsingException e) {
            throw new DayOfWeekParsingException(e.TimePartSource);
        }
    }
}

