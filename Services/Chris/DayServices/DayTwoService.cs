using Domain.Chris.Constants;
using Domain.Chris.DTOs.DayTwo;
using Helpers;

namespace Services.Chris.DayServices;

public class DayTwoService : ChrisDayService, IDayService
{
    private const int Day = 2;

    public override string SolvePartOne()
    {
        // SUM the IDs for ANSWER

        var maxAllowed = new Dictionary<string, int>
        {
            { CubeColours.Red, 12 },
            { CubeColours.Blue, 14 },
            { CubeColours.Green, 13 },
        };

        var lines = FileHelper.GetLines(User, Day);
        var games = lines.Select(ParseLine).ToList();
        var allowedGames = games.Where(game => IsGameAllowed(game, maxAllowed)).ToList();

        return allowedGames.Select(game => game.Id).Sum().ToString();
    }

    public override string SolvePartTwo()
    {
        var lines = FileHelper.GetLines(User, Day);
        var games = lines.Select(ParseLine).ToList();

        var result = 0;
        foreach (var game in games)
        {
            var minimumCubes = GetLowestPossibleCubes(game);
            var power =
                minimumCubes[CubeColours.Red] *
                minimumCubes[CubeColours.Green] *
                minimumCubes[CubeColours.Blue];

            result += power;
        }

        return result.ToString();
    }

    private static Game ParseLine(string line)
    {
        var game = new Game();

        var gameSplit = line.Split(": ");
        game.Id = int.Parse(gameSplit[0].Split(" ")[1]);

        var handfulSplit = gameSplit[1].Split("; ");
        foreach (var handfulLine in handfulSplit)
        {
            var handful = new Handful();

            var groupSplit = handfulLine.Split(", ");
            foreach (var groupLine in groupSplit)
            {
                var cubeDetails = groupLine.Split(" ");
                handful.Groups.Add(
                    new Group
                    {
                        Count = int.Parse(cubeDetails[0]),
                        Colour = cubeDetails[1]
                    }
                );
            }

            game.Handfuls.Add(handful);
        }

        return game;
    }

    private static bool IsGameAllowed(Game game, Dictionary<string, int> allowed) =>
        game.Handfuls.All(handful => IsHandfulAllowed(handful, allowed));

    private static bool IsHandfulAllowed(Handful handful, Dictionary<string, int> allowed) =>
        handful.Groups.All(group => allowed[group.Colour] >= group.Count);

    private static Dictionary<string, int> GetLowestPossibleCubes(Game game)
    {
        var cubes = new Dictionary<string, int>
        {
            { CubeColours.Red, 0 },
            { CubeColours.Green, 0 },
            { CubeColours.Blue, 0 },
        };

        foreach (var handful in game.Handfuls)
        {
            foreach (var group in handful.Groups)
            {
                if (group.Count > cubes[group.Colour])
                {
                    cubes[group.Colour] = group.Count;
                }
            }
        }

        return cubes;
    }
}