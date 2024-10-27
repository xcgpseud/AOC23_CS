namespace Helpers.Chris.Extensions;

public static class StringExtensions
{
    public static (char?, int) FindFirst(this string str, Func<char, bool> predicate)
    {
        for (var i = 0; i < str.Length; i++)
        {
            if (predicate(str[i]))
            {
                return (str[i], i);
            }
        }

        return (null, -1);
    }

    public static (char?, int) FindLast(this string str, Func<char, bool> predicate)
    {
        for (var i = str.Length - 1; i >= 0; i--)
        {
            if (predicate(str[i]))
            {
                return (str[i], i);
            }
        }

        return (null, -1);
    }

    public static ((string, int), (string, int)) FindFirstAndLast(this string str, IEnumerable<string> searches)
    {
        var (firstWord, firstLocation) = ("", str.Length);
        var (lastWord, lastLocation) = ("", 0);

        foreach (var search in searches)
        {
            var firstIndex = str.IndexOf(search, StringComparison.Ordinal);
            var lastIndex = str.LastIndexOf(search, StringComparison.Ordinal);

            if (firstIndex != -1 && firstIndex < firstLocation)
            {
                (firstWord, firstLocation) = (search, firstIndex);
            }

            if (lastIndex > lastLocation)
            {
                (lastWord, lastLocation) = (search, lastIndex);
            }
        }

        return ((firstWord, firstLocation), (lastWord, lastLocation));
    }
}