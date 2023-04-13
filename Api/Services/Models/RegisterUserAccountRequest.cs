using AutoMapper;
using FluentValidation;
using UserAccount.Services;

namespace Api.Services.Models;

public class RegisterUserAccountRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterUserAccountRequestValidator : AbstractValidator<RegisterUserAccountRequest>
{
    public RegisterUserAccountRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("User name is required.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class RegisterUserAccountRequestProfile : Profile
{
    public RegisterUserAccountRequestProfile()
    {
        CreateMap<RegisterUserAccountRequest, RegisterUserAccountModel>();
    }
}

