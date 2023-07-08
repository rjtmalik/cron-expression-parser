using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class MinuteParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("*/10", new int[] { 0, 10, 20, 30, 40, 50 })]
    [InlineData("0-59/10", new int[] { 0, 10, 20, 30, 40, 50 })]
    [InlineData("10-25/11", new int[] { 10, 21 })]
    [InlineData("1-2,10-11", new int[] { 1, 2, 10, 11 })]
    public void MinuteParser_Returns_Results(string minutesPart, int[] expected)
    {
        var result = new MinuteParser().Parse(minutesPart);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-590/10")]
    public void MinuteParser_Throws_Exception(string minutesPart)
    {
        Assert.Throws<MinuteParsingException>(() => new MinuteParser().Parse(minutesPart));
    }
}
