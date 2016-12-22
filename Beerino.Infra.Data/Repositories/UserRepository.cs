using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using System.Linq;

namespace Beerino.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User GetIdByEmail(string email)
        {
            return Db.User.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
