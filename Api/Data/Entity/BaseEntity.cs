using Microsoft.EntityFrameworkCore;

namespace CodingLibraryDSR.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index("Uid", IsUnique = true)]
public abstract class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; set; }

    //[Required] public virtual Guid Uid { get; set; } = Guid.NewGuid();
}