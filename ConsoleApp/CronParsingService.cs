using System;
using System.Text;
using CronEval.Lib.Contracts;

namespace ConsoleApp
{
	public class CronParsingService
	{
		private readonly ICronParser cronParser;

        public CronParsingService(ICronParser cronParser)
		{
			this.cronParser = cronParser;
		}

		public string Parse(string expression)
		{
            return cronParser.ParseCronExpression(expression).ToString();
        }
	}
}

