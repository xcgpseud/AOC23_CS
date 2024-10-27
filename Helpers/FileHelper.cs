namespace Helpers;

public static class FileHelper
{
    private const string DaysFilePath = "Days/";

    public static IEnumerable<string> GetLines(string user, int day)
    {
        return File.ReadAllLines($"{DaysFilePath}/{user}/{day}.txt");
    }

    public static IEnumerable<T> GetLines<T>(string user, int day, Func<string, T> converter)
    {
        return GetLines(user, day).Select(converter);
    }
}