using Database.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UserAccount.Services;

using AutoMapper;
using FluentValidation;

public class UserAccountService : IUserAccountService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Users> _userManager;
    private readonly IModelValidator _registerUserAccountModelValidator;

    public UserAccountService(IMapper mapper, UserManager<Users> userManager,
        IModelValidator registerUserAccountModelValidator)
    {
        this._mapper = mapper;
        this._userManager = userManager;
        this._registerUserAccountModelValidator = registerUserAccountModelValidator;
                                                  
    }

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        //_registerUserAccountModelValidator.Check(model);

        //Find user by email
        var users = await _userManager.FindByEmailAsync(model.Email);
       // if (users != null)
         //   throw new ProcessExeption($"Users account with email {model.Email} already exit");

        //Create user account
        users = new Users()
        {
           // Status = UserStatus.Active,
            Name = model.Name,
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true,
            PhoneNumber = null,
            PhoneNumberConfirmed = false
        };

        var result = await _userManager.CreateAsync(users, model.Password);
       // if (!result.Succeeded)
         //   throw new ProcessExeption(
           //     $"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");

        return _mapper.Map<UserAccountModel>(users);
    }
}           
