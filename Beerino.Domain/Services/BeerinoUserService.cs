using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Domain.Services
{
    public class BeerinoUserService : ServiceBase<BeerinoUser>, IBeerinoUserService
    {
        private readonly IBeerinoUserRepository _beerinoUserRepository;

        public BeerinoUserService(IBeerinoUserRepository beerinoUserRepository) 
            : base(beerinoUserRepository)
        {
            _beerinoUserRepository = beerinoUserRepository;
        }
    }
}
