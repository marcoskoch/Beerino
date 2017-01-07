using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Domain.Interfaces.Services
{
    public interface IBeerinoUserService : IServiceBase<BeerinoUser>
    {
        IEnumerable<BeerinoUser> getBeerinosByUser(IEnumerable<BeerinoUser> beerinos, int id);
    }
}
