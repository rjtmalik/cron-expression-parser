using System;
namespace CronEval.Lib.Contracts
{
	public class DayOfWeekParsingException : Exception
	{
		public DayOfWeekParsingException(string input)
			:base(String.Format("Invalid Day of Week Part: {0}", input))
		{

		}
	}
}

