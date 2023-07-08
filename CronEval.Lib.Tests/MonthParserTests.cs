using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class MonthParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("*/10", new int[] { 1, 11})]
    [InlineData("1-11/10", new int[] { 1, 11 })]
    [InlineData("1-2,10-11", new int[] { 1, 2, 10, 11 })]
    public void MonthParser_Returns_Results(string MonthsPart, int[] expected)
    {
        var result = new MonthParser().Parse(MonthsPart);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-59/10")]
    public void MonthParser_Throws_Exception(string MonthsPart)
    {
        Assert.Throws<MonthParsingException>(() => new MonthParser().Parse(MonthsPart));
    }

}
