namespace Wlva.Api.Entities;

public class Entry
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public decimal Weight { get; set; }
    public int Reps { get; set; }
    public int WeeklySets { get; set; }
    public required int Rir { get; set; }
    public int WeeklyFrequency { get; set; }
    public int ExerciseId { get; set; }
    public required Exercise Exercise { get; set; }
}