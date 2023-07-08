using System.Text;
using System.Xml.Linq;

namespace CronEval.Lib.Contracts;

public struct ParsedCronExpression
{
    int[] Minute { get; }
    int[] Hour { get; }
    int[] DayOfMonth { get; }
    int[] Month { get; }
    int[] DayOfWeek { get; }

    public ParsedCronExpression(int[] minute, int[] hour, int[] dayOfMonth, int[] month, int[] dayOfWeek)
    {
        this.Minute = minute;
        this.Hour = hour;
        this.DayOfMonth = dayOfMonth;
        this.Month = month;
        this.DayOfWeek = dayOfWeek;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine("minute".PadRight(14) + ArrayToString(Minute));
        result.AppendLine("hour".PadRight(14) + ArrayToString(Hour));
        result.AppendLine("day of month".PadRight(14) + ArrayToString(DayOfMonth));
        result.AppendLine("month".PadRight(14) + ArrayToString(Month));
        result.AppendLine("day of week".PadRight(14) + ArrayToString(DayOfWeek));
        result.AppendLine("command".PadRight(14) + "docker run -it --rm cron-parse \"<cron_expression>\"");
        return result.ToString();
    }

    private string ArrayToString(int[] arr)
    {
        var result = string.Empty;
        foreach(var a in arr)
        {
            result += a.ToString() + " ";
        }
        return result.Trim();
    }
}

