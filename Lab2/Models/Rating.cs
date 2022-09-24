namespace Lab2.Models;

public class Rating
{
    public int Id { get; set; }
    public int ProductionId { get; set; }
    public Production Production { get; set; } = null!;
    public string Source { get; set; } = null!;
    public int Stars { get; set; }
}
