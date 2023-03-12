namespace Api.Services.Models;
using FluentValidation;

public class PostCategoriesModel
{
    public Guid Uid { get; set; }
    public string Title { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}

public class PostCategoriesModelValidator : AbstractValidator<PostCategoriesModel>
{
    public PostCategoriesModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Categories is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Categories is required.")
            .MaximumLength(200).WithMessage("Title is long.");

        RuleFor(x => x.DifficultyIndex)
            .NotEmpty().WithMessage("DifficultIndex is required.");
    }
}