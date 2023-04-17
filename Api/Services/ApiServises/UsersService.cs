using AutoMapper;
using Database.Data.Context;
using Database.Data.Entity;
using Api.Services.Models;
using Api.Services.Models;

namespace Api.Services;


public class UsersService
{
    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public UsersService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }
    
    public Task<ICollection<GetUsersModel>> GetAllUsers()
    {
        var user = _mainDbContext
            .Users
            .Select(l => _mapper.Map<GetUsersModel>(l))
            .ToList();
        
        return Task.FromResult<ICollection<GetUsersModel>>(user);
    }

    public void SaveUsers(PostUsersModel postUsersModel)
    {
        var result = _mapper.Map<Users>(postUsersModel);
        _mainDbContext.Users.Add(result);
        _mainDbContext.SaveChanges();
    }
    
    public void UpdateUser(UpdateUsersModel updateUsersModel)
    {
        var result = _mapper.Map<Users>(updateUsersModel);
        _mainDbContext.Users.Update(result);
        _mainDbContext.SaveChanges();
    }
    
    public void DeleteUser(DeleteUsersModel deleteUsersModel)
    {
        //var user = _mainDbContext
            //.Users
            //.First(x => x.Uid == deleteUsersModel.Uid);


       // _mainDbContext.Users.Remove(user);
        _mainDbContext.SaveChanges();
    }
}