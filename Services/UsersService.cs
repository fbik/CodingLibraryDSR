using CodingLibraryDSR.Services.Models;

namespace Services.Models;

public class UsersService
{
    public Task<ICollection<UsersModel>> GetAllUsers()
    {
        return Task.FromResult<ICollection<UsersModel>>(new List<UsersModel>());
    }
}