using System.ComponentModel.DataAnnotations;
using Api.Data.Entity;

namespace Api.Data.Entity;

public class Categories : BaseEntity
{
    public string Title { get; set; }

    /// <summary>
    /// Сделать Title Enum
    /// </summary>
    public int DifficultyIndex { get; set; }

    public virtual ICollection<Problems> Problems { get; set; }
}