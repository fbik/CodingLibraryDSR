namespace CodingLibraryDSR.Services.Models;

public class CommentsModel
{
    public int UsersId { get; set; }
    public int ProblemsId { get; set; }
    public string ContentComments { get; set; }
    public DateTime LeftTime { get; set; }
}