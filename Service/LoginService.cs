using MongoApi.Data;
using MongoApi.Model;
using System.Data.Entity;

namespace MongoApi.Service
{
    public class LoginService
    {
        private readonly DBContext _dbContext;
        public LoginService(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<UserModel> GetUser(UserModel user)
        {
            return await _dbContext.User.
                SingleOrDefaultAsync(x => x.Name == user.Name && x.PSW == user.PSW );
        }

    }
}
