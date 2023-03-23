using Api.Services;
using Api.Services.Models;
using Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("comments")]
public class CommentsController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly CommentsService _commentsService;

    public CommentsController(CommentsService commentsService, CacheService cacheService)
    {
        _commentsService = commentsService;
        _cacheService = cacheService;
    }

    [HttpGet("get")]
    
    public async Task<ICollection<GetCommentsModel>> Get()
    {
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(20));
        var cacheResult = await _cacheService.GetAsync<ICollection<GetCommentsModel>>("Comments");
        if (cacheResult == null)
        {
            var result = await _commentsService.GetAllComments();
            await _cacheService.SetAsync("Comments", result, options);
            return result;
        }

        return cacheResult;
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

