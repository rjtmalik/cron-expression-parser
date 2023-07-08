using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class WildcardPrefixParserTests
{
    [Theory]
    [InlineData("*", new int[] { 1, 2, 3, 4, 5, 6, 7 })]
    [InlineData("*/2", new int[] { 1, 3, 5, 7 })]
    public void MinuteParser_Returns_Results(string someInput, int[] expected)
    {
        var result = new WildcardPrefixParser(1,7, null).Execute(someInput);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1-9")]
    public void MinuteParser_Throws_Exception(string someInput)
    {
        Assert.Throws<NullReferenceException>(() => new WildcardPrefixParser(0, 59, null).Execute(someInput));
    }
}
