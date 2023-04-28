namespace Web.Pages.Problems.Models;

public class ProblemsListItem
{
    public Guid Uid { get; set; }
    public string Language { get; set; }
    public string Category { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Solution { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}