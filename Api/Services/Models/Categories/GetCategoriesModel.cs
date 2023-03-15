using FluentValidation;

namespace Api.Services.Models;

public class GetCategoriesModel
{
    public Guid Uid { get; set; }
    public string Title { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}

public class GetCategoriesModelValidator : AbstractValidator<GetCategoriesModel>
{
    public GetCategoriesModelValidator()
    {
             RuleFor(x => x.Uid)
                 .NotEmpty().WithMessage("Id is required.");

             RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Title is required.")
                 .MaximumLength(50).WithMessage("Title is long.");

             RuleFor(x => x.DifficultyIndex)
                 .NotEmpty().WithMessage("DifficultIndex is required.");
    }
}