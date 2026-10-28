namespace Wlva.Api.Entities;
public class Exercise
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Entry> Entries { get; set; } = new List<Entry>();
}