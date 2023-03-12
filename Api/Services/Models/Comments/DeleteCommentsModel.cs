namespace Api.Services.Models;

public class DeleteCommentsModel
{
    public Guid Uid { get; set; }
    public Guid UsersId { get; set; }
    public Guid ProblemsId { get; set; }
    public string ContentComments { get; set; }
    public DateTime LeftTime { get; set; }
}