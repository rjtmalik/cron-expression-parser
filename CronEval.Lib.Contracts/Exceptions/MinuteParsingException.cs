using System;
namespace CronEval.Lib.Contracts
{
	public class MinuteParsingException: Exception
	{
		public MinuteParsingException(string input)
			:base(String.Format("Invalid Minutes Part: {0}", input))
		{

		}
	}
}

