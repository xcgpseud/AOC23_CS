using Helpers;
using Helpers.Chris;
using Helpers.Chris.Extensions;

namespace Services.Chris.DayServices;

public class DayOneService : ChrisDayService, IDayService
{
    private const int Day = 1;

    private readonly List<(string, int)> _numberWords =
    [
        ("one", 1),
        ("two", 2),
        ("three", 3),
        ("four", 4),
        ("five", 5),
        ("six", 6),
        ("seven", 7),
        ("eight", 8),
        ("nine", 9)
    ];

    private int GetNumberFromWord(string word) => _numberWords
        .FirstOrDefault(tpl => tpl.Item1 == word)
        .Item2;

    public override string SolvePartOne()
    {
        var lines = FileHelper.GetLines(User, Day);

        var result = 0;
        foreach (var line in lines)
        {
            var (first, _) = line.FindFirst(char.IsDigit);
            var (last, _) = line.FindLast(char.IsDigit);

            result += int.Parse($"{first}{last}");
        }

        return result.ToString();
    }

    public override string SolvePartTwo()
    {
        var lines = FileHelper.GetLines(User, Day);

        var result = 0;
        foreach (var line in lines)
        {
            var words = _numberWords.Select(x => x.Item1);
            var ((firstWord, firstWordIndex), (lastWord, lastWordIndex)) = line.FindFirstAndLast(words);
            var (first, firstIndex) = line.FindFirst(char.IsDigit);
            var (last, lastIndex) = line.FindLast(char.IsDigit);

            var left = firstWordIndex < firstIndex
                ? GetNumberFromWord(firstWord)
                : int.Parse(first.ToString() ?? string.Empty);

            var right = lastWordIndex > lastIndex
                ? GetNumberFromWord(lastWord)
                : int.Parse(last.ToString() ?? string.Empty);

            result += int.Parse($"{left}{right}");
        }

        return result.ToString();
    }
}