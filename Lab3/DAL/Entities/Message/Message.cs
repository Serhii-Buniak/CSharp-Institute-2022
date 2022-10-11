namespace DAL.Entities;

public class Message
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = null!;
}