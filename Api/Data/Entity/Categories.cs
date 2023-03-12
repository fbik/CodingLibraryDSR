using System.ComponentModel.DataAnnotations;
using Api.CodingLibraryDSR.Data.Entity;

namespace Api.CodingLibraryDSR.Data.Entity;

public class Categories : BaseEntity
{
    public string Title { get; set; }

    /// <summary>
    /// Сделать Title Enum
    /// </summary>
    public int DifficultyIndex { get; set; }

    public virtual ICollection<Problems> Problems { get; set; }
}