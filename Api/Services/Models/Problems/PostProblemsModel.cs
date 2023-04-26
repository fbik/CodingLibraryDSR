namespace Api.Services.Models;
using FluentValidation;

public class PostProblemsModel
{
    public Guid Uid { get; set; }
    public Guid LanguagesUid { get; set; }
    public Guid CategoriesUid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Solution { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}

public class PostProblemsModelValidator : AbstractValidator<PostProblemsModel>
{
    public PostProblemsModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(2000).WithMessage("Description is long.");

        RuleFor(x => x.Solution)
            .NotEmpty().WithMessage("Solution is required.")
            .MaximumLength(100).WithMessage("Solution is long.");

        RuleFor(x => x.DifficultyIndex)
            .NotEmpty().WithMessage("DifficultyIndex is required.");
    }
}
