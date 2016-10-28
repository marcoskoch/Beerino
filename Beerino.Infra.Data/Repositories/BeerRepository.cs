﻿using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;

namespace Beerino.Infra.Data.Repositories
{
    public class BeerRepository : RepositoryBase<Beer>, IBeerRepository
    {
    }
}
