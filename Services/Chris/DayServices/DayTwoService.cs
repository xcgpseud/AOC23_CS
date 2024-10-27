namespace Services.Chris.DayServices;

public class DayTwoService : DayService, IDayService
{
    public override string SolvePartOne()
    {
        /**
         * Format is always:
         * Game i: i green, i red; i blue etc.
         * ; separates each hand
         * , separates each die in the set
         *
         * Get the IDs of each game that CAN be played with:
         *  12 red, 13 green, 14 blue
         *
         * SUM the IDs for ANSWER
         */
        return "unf";
    }

    public override string SolvePartTwo()
    {
        return "unf";
    }
}