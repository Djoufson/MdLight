using MdLight;

namespace tests.Parsers;

public class UlistTests
{
    private readonly IParser _parser;

    public UlistTests()
    {
        _parser = new Parser();
    }

    [Fact]
    public void ParagraphParse_ShouldPerformProperly()
    {
        // Arrange
        string content = """
        - Monday
        - Tuesday
        - Wednesday
        """;

        string expected = "<ul><li>Monday</li><li>Tuesday</li><li>Wednesday</li></ul>";

        // Act
        var html = _parser.Parse(content);

        // Assert
        Assert.Equal(expected, html);
    }
}
