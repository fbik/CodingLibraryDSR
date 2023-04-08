using Database.Data.Entity;

namespace Database.Data.Entity;

public class Subscriptions : BaseEntity
{
    public string StatusSubscriptions { get; set; }
    
    public virtual Problems Problem { get; set; }
    public virtual Users User { get; set; }
}