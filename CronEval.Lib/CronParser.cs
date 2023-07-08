using System;
using CronEval.Lib.Contracts;

namespace CronEval.Lib
{
	public class CronParser: ICronParser
{
        private readonly IEnumerable<ITimePartParser> timePartParsers;

		public CronParser()
		{
			this.timePartParsers = new ITimePartParser[] { new MinuteParser(), new HourParser(), new DayOfWeekParser(), new MonthParser(), new  DayOfMonthParser()};
        }

		public ParsedCronExpression ParseCronExpression(string cronExpression)
		{
			try
			{
                var result = new List<int[]>();
                var timeParts = cronExpression.Split(" ");
                for (int i = 0; i < timeParts.Length; i++)
                {
                    var timePartParser = timePartParsers.First(x => x.IsMatch((TimePart)i));
                    result.Add(timePartParser.Parse(timeParts[i]));
                }
                return new ParsedCronExpression(result[0], result[1], result[2], result[3], result[4]);
            }
			catch(Exception ex)
			{
                // log if required.
                return new ParsedCronExpression(new int[0], new int[0], new int[0], new int[0], new int[0]);
            }
		}
	}
}