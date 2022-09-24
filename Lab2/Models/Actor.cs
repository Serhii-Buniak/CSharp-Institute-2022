namespace Lab2.Models;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Character> Characters { get; set; } = new List<Character>();
}
