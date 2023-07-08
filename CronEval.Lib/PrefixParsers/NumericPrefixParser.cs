using System;
using CronEval.Lib.Contracts;

namespace CronEval.Lib
{
	public class NumericPrefixParser: IPrefixParser
    {
        private int Min { get; }
        private int Max { get; }
        private IPrefixParser Next { get; }

        public NumericPrefixParser(int min, int max, IPrefixParser next)
        {
            this.Min = min;
            this.Max = max;
            this.Next = next;
        }

		public List<int> Execute(string timePartPossibility)
        {
            if (!CanParse(timePartPossibility))
            {
                return Next.Execute(timePartPossibility);
            }
            var result = new List<int>();
            if (timePartPossibility.Contains('/'))
            {
                //case such as 15/12, 0-15/3
                StepProgress(timePartPossibility, result);
            }
            else
            {
                //such as 0-3, 3
                GradualProgress(timePartPossibility, result);
            }
            return result;
        }

        private bool CanParse(string timePartPossibility)
        {
            return "0123456789".Contains(timePartPossibility[0]);
        }

        /// <summary>
        /// When the cron gradually moving in range or is a constant value
        /// </summary>
        /// <param name="timePartPossibility"></param>
        /// <param name="result"></param>
        /// <exception cref="TimePartParsingException"></exception>
        private void GradualProgress(string timePartPossibility, List<int> result)
        {
            if (!timePartPossibility.Contains('-'))
            {
                var i = -1;
                var isSuccess = Int32.TryParse(timePartPossibility, out i);
                if (!isSuccess)
                {
                    throw new TimePartParsingException(timePartPossibility);
                }
                if (i > Max || i < Min)
                {
                    throw new TimePartParsingException(timePartPossibility);
                }
                result.Add(i);
            }
            else
            {
                var splitted = timePartPossibility.Split('-');
                if (splitted.Length > 2)
                {
                    throw new TimePartParsingException(timePartPossibility);
                }
                var start = Convert.ToInt32(splitted[0].Trim());
                var end = Convert.ToInt32(splitted[1].Trim());
                var i = start;
                while (i <= end)
                {
                    if (i > Max || i < Min)
                    {
                        throw new TimePartParsingException(timePartPossibility);
                    }
                    result.Add(i);
                    i += 1;
                }
            }
        }

        /// <summary>
        /// When the cron expression is having steps within or without the range
        /// </summary>
        /// <param name="timePartPossibility"></param>
        /// <param name="result"></param>
        /// <exception cref="TimePartParsingException"></exception>
        private void StepProgress(string timePartPossibility, List<int> result)
        {
            var splitted = timePartPossibility.Split('/');
            if (splitted.Length > 2)
            {
                throw new TimePartParsingException(timePartPossibility);
            }
            var step = -1;
            var isSuccess = Int32.TryParse(splitted[1], out step);
            if (!isSuccess)
            {
                throw new TimePartParsingException(timePartPossibility);
            }
            var start = Min;
            var end = Max;
            if (splitted[0].Contains('-'))
            {
                var hyphenSplit = splitted[0].Split("-");
                start = Convert.ToInt32(hyphenSplit[0].Trim());
                end = Convert.ToInt32(hyphenSplit[1].Trim());
            }
            else
            {
                start = Convert.ToInt32(splitted[0].Trim());
            }
            var i = start;
            while (i <= end)
            {
                if (i > Max || i < Min)
                {
                    throw new TimePartParsingException(timePartPossibility);
                }
                result.Add(i);
                i += step;
            }
        }
    }
}

