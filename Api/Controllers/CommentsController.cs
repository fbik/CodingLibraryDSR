using Api.Services;
using Api.Services.Models;
using Cache;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
//[Authorize]
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
    //[Authorize(Policy = AppScopes.CommentsRead)]
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
    //[Authorize(Policy = AppScopes.CommentsWrite)]
    public async Task<IActionResult> Post([FromBody] PostCommentsModel request)
    { 
        await _commentsService.SaveComment(request);
        return Ok("CommentPost");
    }
    
    [HttpPut("update")]
    //[Authorize(Policy = AppScopes.CommentsWrite)]
   public IActionResult Update([FromBody] UpdateCommentsModel updateCommentsModel)
    {
        _commentsService.UpdateComment(updateCommentsModel);
        return Ok("CommentsPut");
    }
    
   [HttpDelete("delete")]
   //[Authorize(Policy = AppScopes.CommentsWrite)]
    public IActionResult Delete([FromBody] DeleteCommentsModel deleteCommentsModel)
    {
        _commentsService.DeleteComment(deleteCommentsModel);
        return Ok("CommentDelete");
    }
}

