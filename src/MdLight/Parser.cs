
using System.Text;
using MdLight.Markdown.Base;

namespace MdLight;

public class Parser : IParser
{
    public string Parse(string content)
    {
        return Parse(content.Split("\n"));
    }

    public string Parse(IEnumerable<string> lines)
    {
        var htmlBlocs = TextToBlocs(lines).Select(b => b.ToHtml());
        var sb = new StringBuilder();
        return sb.AppendJoin("", htmlBlocs).ToString();
    }

    private static IEnumerable<Bloc> TextToBlocs(IEnumerable<string> lines)
    {
        int index = 0;
        while(index < lines.Count())
        {
            (Bloc b, index) = Engine.Compute(lines, index);
            yield return b;
        }
    }
}
