using System;
namespace CronEval.Lib
{
	public interface IPrefixParser
	{
        List<int> Execute(string timePartPossibility);

    }
}

