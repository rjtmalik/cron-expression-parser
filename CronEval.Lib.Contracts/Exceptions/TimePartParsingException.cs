using System;
namespace CronEval.Lib.Contracts
{
	public class TimePartParsingException : Exception
	{
		public string TimePartSource { get; }

		public TimePartParsingException(string input)
		{
			this.TimePartSource = input;
		}
	}
}

