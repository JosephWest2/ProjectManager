using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectManager.Data;

namespace ProjectManager.Areas.Identity.Data;

public class SeedUsers
{
    public static async Task CreateSeedUsers(ProjectManagerContext context, IServiceProvider serviceProvider, string adminPassword, string testAccountPassword)
    {
        var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

        if (userManager is null || userManager.Users.Any())
        {
            return;
        }

        List<IdentityUser> users = new List<IdentityUser>
        {
            new IdentityUser
            {
                UserName = "JohnSmith",
                EmailConfirmed = true
            },
            new IdentityUser
            {
                UserName = "JaneDoe",
                EmailConfirmed = true
            },
            new IdentityUser
            {
                UserName = "SusanReed",
                EmailConfirmed = true
            },
            new IdentityUser
            {
                UserName = "RobertDale",
                EmailConfirmed = true
            },
            new IdentityUser
            {
                UserName = "SallyJane",
                EmailConfirmed = true
            }
        };

        var admin = new IdentityUser
        {
            UserName = "Admin",
            EmailConfirmed = true
        };

        await TryCreateUser(userManager, admin, adminPassword);

        foreach (var user in users)
        {
            await TryCreateUser(userManager, user, testAccountPassword);
        }

    }

    private static async Task TryCreateUser(UserManager<IdentityUser> userManager, IdentityUser user, string password)
    {

        await userManager.CreateAsync(user, password);

        if (user is null)
        {
            throw new Exception("Seed Identity User Password is likely not strong enough");
        }

    }
}
