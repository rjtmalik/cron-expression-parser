using System;
namespace CronEval.Lib.Contracts
{
	public class DayOfMonthParsingException : Exception
	{
		public DayOfMonthParsingException(string input)
			:base(String.Format("Invalid Day of Month Part: {0}", input))
		{

		}
	}
}

