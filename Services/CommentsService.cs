using CodingLibraryDSR.Services.Models;

namespace Services.Models;

public class CommentsService
{
    public Task<ICollection<CommentsModel>> GetAllComments()
    {
        return Task.FromResult<ICollection<CommentsModel>>(new List<CommentsModel>());
    }
}