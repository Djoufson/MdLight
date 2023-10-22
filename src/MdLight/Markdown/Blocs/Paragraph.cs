using MdLight.Markdown.Base;

namespace MdLight.Markdown.Blocs;

internal class Paragraph : Bloc
{
    public static readonly Paragraph Default = new(string.Empty);
    protected override string RawContent { get; set; }
    protected override IList<Bloc>? Content { get; set; }
    private Paragraph(string content)
    {
        RawContent = content;
    }

    public override (Bloc, int) Create(IEnumerable<string> lines, int startIndex)
    {
        return (new Paragraph(lines.ElementAt(startIndex)), ++startIndex);
    }

    public override bool Match(IEnumerable<string> lines, int startIndex)
    {
        return false;
    }

    public override string ToHtml()
    {
        return $"<p>{RawContent}</p>";
    }
}
