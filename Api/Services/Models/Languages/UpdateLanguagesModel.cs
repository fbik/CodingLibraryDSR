namespace Api.Services.Models;
using FluentValidation;

public class UpdateLanguagesModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
}

public class UpdateLanguagesModelValidator : AbstractValidator<UpdateLanguagesModel>
{
    public UpdateLanguagesModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Languages is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Version)
            .NotEmpty().WithMessage("Version is required.");

    }

}