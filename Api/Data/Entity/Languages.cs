using System.ComponentModel.DataAnnotations;
using Api.Data.Entity;

namespace Api.Data.Entity;

public class Languages : BaseEntity
{
    public string Name { get; set; }
    /// <summary>
    /// Сделать Name Enum
    /// </summary>
    public string Version { get; set; }
    
    public  virtual ICollection<Problems> Problems { get; set; }
}