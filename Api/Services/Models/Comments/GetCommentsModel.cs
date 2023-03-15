using FluentValidation;

namespace Api.Services.Models;

public class GetCommentsModel
{
    public Guid Uid { get; set; }
    public Guid UsersId { get; set; }
    public Guid ProblemsId { get; set; }
    public string ContentComments { get; set; }
    public DateTime LeftTime { get; set; }
}

public class GetCommentsModelValidator : AbstractValidator<GetCommentsModel>
{
    public GetCommentsModelValidator()
    {
        RuleFor(x => x.ContentComments)
            .NotEmpty().WithMessage("ContentsComment is required.")
            .MaximumLength(100).WithMessage("ContentComment ia long.");

        RuleFor(x => x.LeftTime)
            .NotEmpty().WithMessage("LeftTime is required.");
    }
}