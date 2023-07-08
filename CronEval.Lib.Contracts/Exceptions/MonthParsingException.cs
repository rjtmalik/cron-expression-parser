using System;
namespace CronEval.Lib.Contracts
{
	public class MonthParsingException : Exception
	{
		public MonthParsingException(string input)
			:base(String.Format("Invalid Month Part: {0}", input))
		{

		}
	}
}

