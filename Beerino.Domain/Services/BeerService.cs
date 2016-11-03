using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Domain.Services
{
    public class BeerService : ServiceBase<Beer>, IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository) 
            : base(beerRepository)
        {
            _beerRepository = beerRepository;
        }
    }
}
