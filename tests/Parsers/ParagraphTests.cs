using MdLight;

namespace tests.Parsers;

public class ParagraphTests
{
    private readonly IParser _parser;

    public ParagraphTests()
    {
        _parser = new Parser();
    }

    [Theory]
    [InlineData("Hello World", "<p>Hello World</p>")]
    public void ParagraphParse_ShouldPerformProperly(string mdContent, string expectedHtmlContent)
    {
        // Act
        var result = _parser.Parse(mdContent);

        // Assert
        Assert.Equal(result, expectedHtmlContent);
    }
}
