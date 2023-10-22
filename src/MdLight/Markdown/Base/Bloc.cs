namespace MdLight.Markdown.Base;

internal abstract class Bloc
{
    protected abstract string RawContent { get; set; }
    protected abstract IList<Bloc>? Content { get; set; }
    public abstract string ToHtml();
    public abstract (Bloc, int) Create(IEnumerable<string> lines, int startIndex);
    public abstract bool Match(IEnumerable<string> lines, int startIndex);
}
