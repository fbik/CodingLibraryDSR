namespace Api.CodingLibraryDSR.Services.Models;
using FluentValidation;

public class PostSubscriptionsModel
{
    public Guid Uid { get; set; }
    public Guid ProblemsId { get; set; }
    public Guid UsersId { get; set; }
    public string StatusSubscriptions { get; set; } 
}

public class PostSubscriptionModelValidator : AbstractValidator<PostSubscriptionsModel>
{
    public PostSubscriptionModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.StatusSubscriptions)
            .NotEmpty().WithMessage("StatusSubscriptions is required.")
            .MaximumLength(100).WithMessage("StatusSubscriptions is long.");
    }
}