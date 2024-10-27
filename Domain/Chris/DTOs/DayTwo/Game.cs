namespace Domain.Chris.DTOs.DayTwo;

public class Game
{
    public int Id { get; set; }

    public IList<Handful> Handfuls { get; set; } = new List<Handful>();
}