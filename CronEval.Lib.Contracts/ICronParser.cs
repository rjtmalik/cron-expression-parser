namespace CronEval.Lib.Contracts;

public interface ICronParser
{
    ParsedCronExpression ParseCronExpression(string cronExpression);
}
