using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class HourParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("*/10", new int[] { 0, 10, 20})]
    [InlineData("0-20/10", new int[] { 0, 10, 20 })]
    [InlineData("10-25/11", new int[] { 10, 21 })]
    [InlineData("1-2,10-11", new int[] { 1, 2, 10, 11 })]
    public void HourParser_Returns_Results(string hoursPart, int[] expected)
    {
        var result = new HourParser().Parse(hoursPart);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-59/10")]
    public void HourParser_Throws_Exception(string hoursPart)
    {
        Assert.Throws<HourParsingException>(() => new HourParser().Parse(hoursPart));
    }

}
