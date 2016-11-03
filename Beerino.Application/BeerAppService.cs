using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Application
{
    public class BeerAppService : AppServiceBase<Beer>, IBeerAppService
    {
        private readonly IBeerService _beerService;

        public BeerAppService(IBeerService beerService) 
            : base(beerService)
        {
            _beerService = beerService;
        }
    }
}
