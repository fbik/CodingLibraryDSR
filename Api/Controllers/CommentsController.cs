using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;

namespace Api.Controllers;
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
    
    [HttpPost("post")]
    public IActionResult Post([FromBody] PostCommentsModel request)
    { 
        _commentsService.SaveComment(request);
        return Ok("CommentPost");
    }
    
    [HttpPut("update")]
   public IActionResult Update([FromBody] UpdateCommentsModel updateCommentsModel)
    {
        _commentsService.UpdateComment(updateCommentsModel);
        return Ok("CommentsPut");
    }
    
   [HttpDelete("delete")]
    public IActionResult Delete([FromBody] DeleteCommentsModel deleteCommentsModel)
    {
        _commentsService.DeleteComment(deleteCommentsModel);
        return Ok("CommentDelete");
    }
}

