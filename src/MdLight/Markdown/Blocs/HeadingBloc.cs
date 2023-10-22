using MdLight.Markdown.Base;

namespace MdLight.Markdown.Blocs;

internal class HeadingBloc : Bloc
{
    public override string Pattern => "";

    protected override string RawContent { get; set; } = string.Empty;
    protected override IList<Bloc>? Content { get; set; }

    public override string ToHtml()
    {
        throw new NotImplementedException();
    }
}
