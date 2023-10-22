using System.Reflection;
using MdLight.Markdown.Base;

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
            if(type.IsSubclassOf(baseType))
                yield return type;
        }
    }

    internal static (Bloc b, int index) Compute(IEnumerable<string> lines, int startIndex)
    {
        // Check if the current index matches any bloc criteria
        foreach (var type in _types)
        {
            var defaultProperty = type.GetProperty("Default", BindingFlags.NonPublic | BindingFlags.Static);
            var defaultInstance = (Bloc) defaultProperty!.GetValue(null)!;
            if(defaultInstance.Match(lines, startIndex))
                return defaultInstance.Create(lines, startIndex);
        }

        // If not we just return a default bloc
        return (null!, lines.Count());
    }
}
