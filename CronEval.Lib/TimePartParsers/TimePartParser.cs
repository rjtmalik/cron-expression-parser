using System.Linq;
using CronEval.Lib.Contracts;

namespace CronEval.Lib;

public class TimePartParser
{
    private IPrefixParser prefixParser { get; }

    public TimePartParser(int min, int max)
    {
        this.prefixParser = new WildcardPrefixParser(min, max, new NumericPrefixParser(min, max, new UnknownPrefixParser()));
    }

    public virtual int[] Parse(string timePart)
    {
        var temp = new List<int>();
        var timePartPossibilities = timePart.Split(",");
        foreach(var timePartPossibility in timePartPossibilities)
        {
            temp.AddRange(prefixParser.Execute(timePartPossibility));
        }
        var memo = new HashSet<int>();
        var result = new List<int>();
        foreach(var t in temp)
        {
            if (!memo.Contains(t))
            {
                memo.Add(t);
                result.Add(t);
            }
        }
        return result.OrderBy(x => x).ToArray();
    }
}

