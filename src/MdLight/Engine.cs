using System.Reflection;
using MdLight.Markdown.Base;
using MdLight.Markdown.Blocs;

namespace MdLight;

public class Engine
{
    private static readonly Type[] _types;
    static Engine()
    {
        _types = RetrieveTypes().ToArray();
    }

    private static IEnumerable<Type> RetrieveTypes()
    {
        var baseType = typeof(Bloc);
        foreach (var type in baseType.Assembly.GetTypes())
        {
            if(type.IsSubclassOf(baseType) && type != typeof(Ulist.ListItem))
                yield return type;
        }
    }

    internal static (Bloc b, int index) Compute(IEnumerable<string> lines, int startIndex)
    {
        // Check if the current index matches any bloc criteria
        foreach (var type in _types)
        {
            var defaultProperty = type.GetField("Default", BindingFlags.Public | BindingFlags.Static);
            var defaultInstance = (Bloc) defaultProperty!.GetValue(null)!;
            if(defaultInstance.Match(lines, startIndex))
            {
                var (b, i) = defaultInstance.Create(lines, startIndex);
                return (b, i);
            }
        }

        // If not we just return a default bloc
        return (Paragraph.Default.Create(lines, startIndex).Item1, lines.Count());
    }
}
