using System.ComponentModel.DataAnnotations;

namespace CodingLibraryDSR.Data.Entity;

public class Languages : BaseEntity
{
    public string Name { get; set; }
    public string Version { get; set; }
    
    public virtual ICollection<Categories> Categories { get; set; }
    public  virtual ICollection<Problems> Problems { get; set; }
}