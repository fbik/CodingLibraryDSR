namespace Api.Services.Models;
using FluentValidation;

public class PostLanguagesModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
}

public class PostLanguagesModelValidator : AbstractValidator<PostLanguagesModel>
{
    public PostLanguagesModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Languages is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Version)
            .NotEmpty().WithMessage("Version is required.");
        
    }
        
}