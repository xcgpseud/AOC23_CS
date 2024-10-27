// See https://aka.ms/new-console-template for more information

using Domain.Constants;
using Helpers.Chris;
using Services;

const string user = Users.Chris;

var results = new List<(string, string)>();

var services = ReflectionHelper.CreateInstancesOfImplementations<DayService>(user);
services.ForEach(
    service => results.Add(
        (
            service.SolvePartOne(),
            service.SolvePartTwo()
        )
    )
);

var day = 1;
foreach (var (partOne, partTwo) in results)
{
    Console.WriteLine($"Day {day}");
    Console.WriteLine($"Part One: {partOne}");
    Console.WriteLine($"Part Two: {partTwo}");

    day++;
}

Console.WriteLine("Done");