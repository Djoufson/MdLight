namespace MdLight;

public interface IParser
{
    /// <summary>
    /// The parse method is used to take a specific string content, and parse it into another output format
    /// </summary>
    /// <param name="content">The input we want to parse</param>
    /// <returns>The parsed content</returns>
    string Parse(string content);

    string Parse(IEnumerable<string> lines);
}
