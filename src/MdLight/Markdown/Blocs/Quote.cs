using MdLight.Markdown.Base;

namespace MdLight.Markdown.Blocs;

internal class Quote : Bloc
{
    public static Quote Default = new("> ");
    protected override string RawContent { get; set; }
    private readonly string _content;

    private Quote(string rawContent)
    {
        RawContent = rawContent;
        _content = rawContent[1..].Trim();
    }

    protected override IList<Bloc>? Content { get; set; }

    public override (Bloc, int) Create(IEnumerable<string> lines, int startIndex)
    {
        return (new Quote(lines.ElementAt(startIndex)), ++startIndex);
    }

    public override bool Match(IEnumerable<string> lines, int startIndex)
    {
        return lines.ElementAt(startIndex).StartsWith('>');
    }

    public override string ToHtml()
    {
        return $"<quote>{_content}</quote>";
    }
}
