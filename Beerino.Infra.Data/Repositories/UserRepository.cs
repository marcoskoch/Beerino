using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using System.Linq;

namespace Beerino.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public int GetIdByEmail(string email)
        {
            var user = Db.User.Where(u => u.Email == email).Single();
            return user.UserID;
        }
    }
}
