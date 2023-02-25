namespace CodingLibraryDSR.Services.Models;

public class UsersModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public string UserStatus { get; set; } = String.Empty;
}