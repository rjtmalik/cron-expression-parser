using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class DayOfMonthParser: TimePartParser, ITimePartParser
{
    public DayOfMonthParser()
        : base(1, 31) { }

    public bool IsMatch(TimePart timePart)
    {
        return TimePart.DayOfMonth == timePart;
    }

    public override int[] Parse(string timePart)
    {
        try
        {
            return base.Parse(timePart);
        }
        catch(TimePartParsingException e) {
            throw new DayOfMonthParsingException(e.TimePartSource);
        }
    }
}

