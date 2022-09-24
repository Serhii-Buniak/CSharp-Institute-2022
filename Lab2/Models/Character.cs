namespace Lab2.Models;

public class Character
{
    public int Id { get; set; }
    public int ProductionId { get; set; }
    public Production Production { get; set; } = null!;
    public string Name { get; set; } = null!;
    public Actor Actor { get; set; } = null!;
    public int ActorId { get; set; }
}
