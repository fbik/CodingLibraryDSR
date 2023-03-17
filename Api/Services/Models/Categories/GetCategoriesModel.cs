using FluentValidation;

namespace Api.Services.Models;

public class GetCategoriesModel
{
    public Guid Uid { get; set; }
    public string Title { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}
