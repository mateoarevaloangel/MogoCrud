using Microsoft.AspNetCore.Identity;
namespace MongoApi.Model
{
    public class UserModel:IdentityUser
    {
        public string? Name { get; set; } //= default!;
        public string? PSW { get; set; } //= default!;
    }
}
