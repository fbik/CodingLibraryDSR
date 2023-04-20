namespace Web.Pages.Problems.Models;

public class ProblemsListItem
{
    public Guid Uid { get; set; }
    public Guid LanguagesId { get; set; }
    public Guid CategoriesId { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Solution { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}