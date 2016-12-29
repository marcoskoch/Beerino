using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Application.Interface
{
    public interface ITaskBeerAppService : IAppServiceBase<TaskBeer>
    {
        TaskBeer getNextTaskBeer(int beerId, int actualTaskBeerOrdem);

        IEnumerable<TaskBeer> getTasksByBeerID(int beerId);
    }
}
