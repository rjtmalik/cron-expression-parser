using CronEval.Lib.Contracts;

namespace CronEval.Lib
{
	public class UnknownPrefixParser: IPrefixParser
    {
        public List<int> Execute(string timePartPossibility)
        {
            throw new TimePartParsingException(timePartPossibility);
        }

    }
}

