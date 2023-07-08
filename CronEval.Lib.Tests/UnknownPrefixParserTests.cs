using CronEval.Lib;
using CronEval.Lib.Contracts;

namespace CronEval.Lib.Tests;

public class UnknownPrefixParserTests
{
    [Theory]
    [InlineData("1-/")]
    [InlineData("/-/")]
    [InlineData("0-590/10")]
    [InlineData("1-2,10-11")]
    public void UnknownPrefixParser_Always_Throws_Exception(string someInput)
    {
        Assert.Throws<TimePartParsingException>(() => new UnknownPrefixParser().Execute(someInput));
    }
}
