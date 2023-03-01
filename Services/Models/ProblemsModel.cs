
namespace CodingLibraryDSR.Services.Models;

public class ProblemsModel
{
    public Guid Uid { get; set; }
    public int LanguagesId { get; set; }
    public int CategoriesId { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Solution { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
    
}