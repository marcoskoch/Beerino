﻿using Beerino.Domain.Entities;

namespace Beerino.Application.Interface
{
    public interface ITaskBeerAppService : IAppServiceBase<TaskBeer>
    {
        TaskBeer getNextTaskBeer(int beerId, int actualTaskBeerOrdem);
    }
}
