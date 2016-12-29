using Beerino.Domain.Entities;
using System.Collections.Generic;

namespace Beerino.Domain.Interfaces.Services
{
    public interface ITaskBeerService : IServiceBase<TaskBeer>
    {
        TaskBeer getNextTaskBeer(IEnumerable<TaskBeer> taskBeer, int beerId, int order);

        IEnumerable<TaskBeer> getTasksByBeerID(IEnumerable<TaskBeer> tasksBeer, int beerID);
    }
}
