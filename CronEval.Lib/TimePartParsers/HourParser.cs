using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class HourParser: TimePartParser, ITimePartParser
{
    public HourParser()
        : base(0, 23) { }

    public bool IsMatch(TimePart timePart)
    {
        return TimePart.Hour == timePart;
    }

    public override int[] Parse(string timePart)
    {
        try
        {
            return base.Parse(timePart);
        }
        catch(TimePartParsingException e) {
            throw new HourParsingException(e.TimePartSource);
        }
    }
}

