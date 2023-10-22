using System.Text;
using MdLight.Markdown.Base;

namespace MdLight.Markdown.Blocs;

internal class Ulist : Bloc
{
    private static readonly StringBuilder _sb = new();
    public static Ulist Default = new("- ");
    protected override string RawContent { get; set; } = string.Empty;
    private readonly string _content;

    protected override IList<Bloc>? Content { get; set; } = new List<Bloc>();
    public Ulist(string content)
    {
        RawContent = content;
        _content = content[1..].Trim();
    }

    public override (Bloc, int) Create(IEnumerable<string> lines, int startIndex)
    {
        int index = startIndex;
        do
        {
            Content!.Add(CreateItem(lines.ElementAt(index)));
            index++;
        } while(index < lines.Count() && Match(lines, index));

        return (this, ++index);
    }

    private static ListItem CreateItem(string content)
    {
        return new ListItem(content);
    }

    public override bool Match(IEnumerable<string> lines, int startIndex)
    {
        var firstElement = lines.ElementAt(startIndex);
        return firstElement.StartsWith('-') || firstElement.StartsWith('*');
    }

    public override string ToHtml()
    {
        _sb.Clear();
        return _sb
            .Append("<ul>")
            .AppendJoin("", Content!.Select(i => i.ToHtml()))
            .Append("</ul>")
            .ToString();
    }

    internal class ListItem : Bloc
    {
        protected override string RawContent { get; set; } = "";
        protected override IList<Bloc>? Content { get; set; }
        private readonly string _content;
        internal ListItem(string content)
        {
            RawContent = content;
            _content = content[1..].Trim();
        }

        public override (Bloc, int) Create(IEnumerable<string> lines, int startIndex)
        {
            throw new NotImplementedException();
        }

        public override bool Match(IEnumerable<string> lines, int startIndex)
        {
            throw new NotImplementedException();
        }

        public override string ToHtml()
        {
            return $"<li>{_content}</li>";
        }
    }
}
