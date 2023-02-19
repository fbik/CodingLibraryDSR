using System.ComponentModel.DataAnnotations;

namespace CodingLibraryDSR.Data.Entity;

public class Categories : BaseEntity
{
    public string Title { get; set; }

    /// <summary>
    /// Сделать Title Enum
    /// </summary>
    public string DifficultyIndex { get; set; }

    public virtual ICollection<Problems> Problems { get; set; }
}