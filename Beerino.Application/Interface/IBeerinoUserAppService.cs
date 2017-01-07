using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Application.Interface
{
    public interface IBeerinoUserAppService : IAppServiceBase<BeerinoUser>
    {
        IEnumerable<BeerinoUser> getBeerinoByUser(int id);
    }
}
