using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        IEnumerable<User> getSpecialUsers(IEnumerable<User> users);
    }
}
