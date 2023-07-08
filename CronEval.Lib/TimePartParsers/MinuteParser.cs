using System.Linq;
using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class MinuteParser: TimePartParser, ITimePartParser
{
    public MinuteParser()
        :base(0, 59){}

    public bool IsMatch(TimePart timePart)
    {
        return TimePart.Minute == timePart;
    }

    public override int[] Parse(string timePart)
    {
        try
        {
            return base.Parse(timePart);
        }
        catch (TimePartParsingException e)
        {
            throw new MinuteParsingException(e.TimePartSource);
        }
    }
}

