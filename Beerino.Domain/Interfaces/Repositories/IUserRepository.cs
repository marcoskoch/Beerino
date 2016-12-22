using Beerino.Domain.Entities;

namespace Beerino.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetIdByEmail(string email);
    }
}
