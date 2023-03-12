using FluentValidation;

namespace Api.Services.Models;

public class GetLanguagesModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
}

public class GetLanguagesModelValidator : AbstractValidator<GetLanguagesModel>
{
    public GetLanguagesModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Languages is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Version)
            .NotEmpty().WithMessage("Version is required.");
        
    }
        
}