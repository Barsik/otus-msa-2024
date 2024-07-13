using Obavi.Modules.Users.Core;

namespace Obavi.Modules.Users.Models;

public class UpdateUser
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public static User ToUser(UpdateUser updateUser)
    {
        return new User
        {
            UserName = updateUser.UserName,
            FirstName = updateUser.FirstName,
            LastName = updateUser.LastName,
            Email = updateUser.Email
        };
    }
    
    public static User ToUser(UpdateUser updateUser, Guid userId)
    {
        return new User
        {
            Id =userId,
            UserName = updateUser.UserName,
            FirstName = updateUser.FirstName,
            LastName = updateUser.LastName,
            Email = updateUser.Email
        };
    }
}