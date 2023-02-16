using System.ComponentModel.DataAnnotations;

namespace CodingLibraryDSR.Data.Entity;

public class Categories : BaseEntity
{
    public string Title { get; set; }
    public string DifficultyIndex { get; set; }
    public string Mathematical_colculations { get; set; }
    public string String_methods { get; set; }

    public virtual ICollection<Problems> Problems { get; set; }
    
    public virtual ICollection<Languages> Languages { get; set; }
}