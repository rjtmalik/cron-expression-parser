using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class DayOfWeekParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("*/2", new int[] { 0, 2, 4, 6})]
    [InlineData("0-2/1", new int[] { 0, 1, 2 })]
    [InlineData("1-2,5-6", new int[] { 1, 2, 5, 6 })]
    public void DayOfWeekParser_Returns_Results(string DayOfWeeksPart, int[] expected)
    {
        var result = new DayOfWeekParser().Parse(DayOfWeeksPart);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-59/10")]
    public void DayOfWeekParser_Throws_Exception(string DayOfWeeksPart)
    {
        Assert.Throws<DayOfWeekParsingException>(() => new DayOfWeekParser().Parse(DayOfWeeksPart));
    }

}
