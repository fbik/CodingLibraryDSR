using System.ComponentModel.DataAnnotations;
using Database.Data.Entity;

namespace Database.Data.Entity;

public class Languages : BaseEntity
{
    public string Name { get; set; }
    /// <summary>
    /// Сделать Name Enum
    /// </summary>
    public string Version { get; set; }
    
    public  virtual ICollection<Problems> Problems { get; set; }
}