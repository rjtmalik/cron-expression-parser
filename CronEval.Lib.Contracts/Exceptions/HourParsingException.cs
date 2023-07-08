using System;
namespace CronEval.Lib.Contracts
{
	public class HourParsingException : Exception
	{
		public HourParsingException(string input)
			:base(String.Format("Invalid Hours Part: {0}", input))
		{

		}
	}
}

