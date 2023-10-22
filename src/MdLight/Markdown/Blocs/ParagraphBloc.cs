using MdLight.Markdown.Base;

namespace MdLight.Markdown.Blocs;

internal class ParagraphBloc : Bloc
{
    public override string Pattern => "";
    protected override IList<Bloc>? Content { get; set; }
    protected override string RawContent { get; set; }

    public ParagraphBloc(string rawContent)
    {
        RawContent = rawContent;
    }

    public override string ToHtml()
    {
        return $"<p>{RawContent}</p>";
    }
}
