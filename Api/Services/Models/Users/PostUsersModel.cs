namespace Api.Services.Models;

using FluentValidation;

public class PostUsersModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public string UserStatus { get; set; } = String.Empty;
}

public class PostUsersModelValidator : AbstractValidator<PostUsersModel>
{
    public PostUsersModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Users is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name is long.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Not email.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(100).WithMessage("Password is long.");

        RuleFor(x => x.UserStatus)
            .NotEmpty().WithMessage("UserStatus is required.");
    }
}