using Api.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserAccount.Services;

namespace Api.Controllers;

[ApiController]

public class AccountsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<AccountsController> _logger;
    private readonly IUserAccountService _userAccountService;

    public AccountsController(IMapper mapper, ILogger<AccountsController> logger,
        IUserAccountService userAccountService)
    {
        this._mapper = mapper;
        this._logger = logger;
        this._userAccountService = userAccountService;
    }

    [HttpPost("")]
    public async Task<UserAccountResponse> Register([FromQuery] RegisterUserAccountRequest request)
    {
        var users = await _userAccountService.Create(_mapper.Map<RegisterUserAccountModel>(request));

        var response = _mapper.Map<UserAccountResponse>(users);

        return response;
    }
}