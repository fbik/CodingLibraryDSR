using AutoMapper;
using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;

public class UsersService
{
    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public UsersService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }
    
    public Task<ICollection<UsersModel>> GetAllUsers()
    {
        var users = _mainDbContext
            .Users
            .Select(l => _mapper.Map<UsersModel>(l))
            .ToList();
        
        return Task.FromResult<ICollection<UsersModel>>(users);
    }
}