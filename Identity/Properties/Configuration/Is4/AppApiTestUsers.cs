using Duende.IdentityServer.Test;

namespace Identity.Properties.Configuration;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "daniil@tst.com",
                Password = "password"
            }
        };
}

