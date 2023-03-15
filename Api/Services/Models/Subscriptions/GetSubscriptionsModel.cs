using FluentValidation;

namespace Api.CodingLibraryDSR.Services.Models;

public class GetSubscriptionsModel
{
    public Guid Uid { get; set; }
    public Guid ProblemsId { get; set; }
    public Guid UsersId { get; set; }
    public string StatusSubscriptions { get; set; }
}

public class GetSubscriptionModelValidator : AbstractValidator<GetSubscriptionsModel>
{
    public GetSubscriptionModelValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.StatusSubscriptions)
            .NotEmpty().WithMessage("StatusSubscriptions is required.")
            .MaximumLength(100).WithMessage("StatusSubscriptions is long.");
    }
}