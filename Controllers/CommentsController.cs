using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("comments")]
public class CommentsController : ControllerBase
{
    private readonly CommentsService _commentsService;

    public CommentsController(CommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet(Name = "GetComments")]

    public async Task<ICollection<CommentsModel>> Get()
    {
        var result = await _commentsService.GetAllComments();
        return result;
    }
}