using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Application.Interface
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        IEnumerable<User> getSpecialUsers();
        int GetIdByEmail(string email);
    }
}
