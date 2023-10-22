using MdLight;

namespace tests.Parsers;

public class QuoteTests
{
    private readonly IParser _parser;

    public QuoteTests()
    {
        _parser = new Parser();
    }

    [Theory]
    [InlineData("> Hello World", "<quote>Hello World</quote>")]
    public void ParagraphParse_ShouldPerformProperly(string mdContent, string expectedHtmlContent)
    {
        // Act
        var result = _parser.Parse(mdContent);

        // Assert
        Assert.Equal(result, expectedHtmlContent);
    }
}
