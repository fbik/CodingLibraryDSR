namespace Api.CodingLibraryDSR.Services.Models;

public class SubscriptionsModel
{
    public Guid Uid { get; set; }
    public Guid ProblemsId { get; set; }
    public Guid UsersId { get; set; }
    public string StatusSubscriptions { get; set; }
}