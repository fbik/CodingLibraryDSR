using FluentValidation;

namespace Web.Pages.Problems.Models;

public class ProblemsModel
{
    public Guid? Uid { get; set; }
    public int? Id { get; set; }
    public Guid LanguagesId { get; set; }
    public int CategoriesId { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Solution { get; set; } = String.Empty;
    public uint DifficultyIndex { get; set; }
}

public class ProblemsModelValidator : AbstractValidator<ProblemsModel>
{
    public ProblemsModelValidator()
    {
        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(255).WithMessage("Description is length");

        RuleFor(v => v.CategoriesId)
            .NotEmpty().WithMessage("Please, not categories");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ProblemsModel>.CreateWithOptions((ProblemsModel)model,
            x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}