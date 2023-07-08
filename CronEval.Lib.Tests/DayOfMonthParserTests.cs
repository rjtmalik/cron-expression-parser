using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class DayOfMonthParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("*/10", new int[] { 1, 11, 21, 31})]
    [InlineData("1-20/10", new int[] { 1, 11 })]
    [InlineData("1-2,10-11", new int[] { 1, 2, 10, 11 })]
    public void DayOfMonthParser_Returns_Results(string DayOfMonthsPart, int[] expected)
    {
        var result = new DayOfMonthParser().Parse(DayOfMonthsPart);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-59/10")]
    public void DayOfMonthParser_Throws_Exception(string DayOfMonthsPart)
    {
        Assert.Throws<DayOfMonthParsingException>(() => new DayOfMonthParser().Parse(DayOfMonthsPart));
    }

}
