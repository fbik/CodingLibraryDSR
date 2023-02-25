namespace CodingLibraryDSR.Services.Models;

public class SubscriptionsModel
{
    public Guid Uid { get; set; }
    public int ProblemsId { get; set; }
    public int UsersId { get; set; }
    public string StatusSubscriptions { get; set; }
}