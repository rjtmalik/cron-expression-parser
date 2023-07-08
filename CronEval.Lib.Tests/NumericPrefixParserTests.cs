using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class NumericPrefixParserTests
{
    [Theory]
    [InlineData("1", new int[] { 1 })]
    [InlineData("1-2", new int[] { 1, 2 })]
    [InlineData("1-5", new int[] { 1, 2, 3, 4, 5 })]
    [InlineData("0-59/10", new int[] { 0, 10, 20, 30, 40, 50 })]
    public void MinuteParser_Returns_Results(string someInput, int[] expected)
    {
        var result = new NumericPrefixParser(0,59, null).Execute(someInput);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("*")]
    public void MinuteParser_Throws_Exception(string someInput)
    {
        Assert.Throws<System.NullReferenceException>(() => new NumericPrefixParser(0, 59, null).Execute(someInput));
    }
}
