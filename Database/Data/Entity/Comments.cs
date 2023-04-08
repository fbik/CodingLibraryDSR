using Database.Data.Entity;

namespace Database.Data.Entity;

public class Comments : BaseEntity
{
   public string ContentComments { get; set; }
   public DateTime LeftTime { get; set; }
   
    public virtual Problems Problem { get; set; }
    public virtual Users User { get; set; }
}