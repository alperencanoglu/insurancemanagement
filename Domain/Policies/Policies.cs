namespace Domain;

public class Policies 
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string UserId  { get; set; }
    public User.User User { get; set; }
}