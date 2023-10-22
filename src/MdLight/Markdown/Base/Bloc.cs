namespace MdLight.Markdown.Base;

internal abstract class Bloc
{
    public abstract string Pattern { get; }
    protected abstract string RawContent { get; set; }
    protected abstract IList<Bloc>? Content { get; set; }

    public abstract string ToHtml();
}
