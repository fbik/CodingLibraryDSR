namespace CodingLibraryDSR.Data.Entity;

public class Users : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string UserStatus { get; set; }

    public virtual ICollection<Comments> Comments { get; set; }
    public virtual ICollection<Subscriptions> Subscritions { get; set; }
}