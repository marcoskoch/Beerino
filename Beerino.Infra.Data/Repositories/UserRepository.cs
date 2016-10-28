using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;

namespace Beerino.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
    }
}
