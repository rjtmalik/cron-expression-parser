using System;
using CronEval.Lib.Contracts;

namespace CronEval.Lib
{
	public class WildcardPrefixParser: IPrefixParser
	{
        private int Min { get; }
        private int Max { get; }
        private IPrefixParser Next { get; }

        public WildcardPrefixParser(int min, int max, IPrefixParser next)
        {
            this.Min = min;
            this.Max = max;
            this.Next = next;
        }

        public List<int> Execute(string timePartPossibility)
        {
            if(!CanParse(timePartPossibility))
            {
                return Next.Execute(timePartPossibility);
            }

            var result = new List<int>();
            
            if (timePartPossibility.Length == 1)
            {
                //for values such as *
                return Enumerable.Range(Min, Max).ToList();
            }
            else if (timePartPossibility.Length >= 3 && timePartPossibility[1] == '/' && "123456789".Contains(timePartPossibility[2]))
            {
                //for values such as */2
                StepProgress(timePartPossibility, result);
            }
            else
            {
                throw new TimePartParsingException(timePartPossibility);
            }
            return result;
        }

        /// <summary>
        /// When the cron is indicating steps progress
        /// </summary>
        /// <param name="timePartPossibility"></param>
        /// <param name="result"></param>
        /// <exception cref="TimePartParsingException"></exception>
        private void StepProgress(string timePartPossibility, List<int> result)
        {
            var step = Convert.ToInt32(timePartPossibility.Split("/")[1]);
            var i = Min;
            while (i <= Max)
            {
                if (i > Max || i < Min)
                {
                    throw new TimePartParsingException(timePartPossibility);
                }
                result.Add(i);
                i += step;
            }
        }

        private bool CanParse(string timePartPossibility)
        {
            return timePartPossibility.StartsWith('*');
        }
    }
}

