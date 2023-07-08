using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class MonthParser : TimePartParser, ITimePartParser
{
    public MonthParser()
        : base(1, 12) { }

    public bool IsMatch(TimePart timePart)
    {
        return TimePart.Month == timePart;
    }

    public override int[] Parse(string timePart)
    {
        try
        {
            return base.Parse(timePart);
        }
        catch(TimePartParsingException e) {
            throw new MonthParsingException(e.TimePartSource);
        }
    }
}

