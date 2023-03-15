namespace Api.Services.Models;
using FluentValidation;

public class PostCommentsModel
{
    public Guid Uid { get; set; }
    public Guid UsersId { get; set; }
    public Guid ProblemsId { get; set; }
    public string ContentComments { get; set; }
    public DateTime LeftTime { get; set; }
}

public class PostCommentsModelValidator : AbstractValidator<PostCommentsModel>
{
    public PostCommentsModelValidator()
    {
        RuleFor(x => x.ContentComments)
            .NotEmpty().WithMessage("ContentsComment is required.")
            .MaximumLength(100).WithMessage("ContentComment ia long.");

        RuleFor(x => x.LeftTime)
            .NotEmpty().WithMessage("LeftTime is required.");
    }
}