using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<BeerinoUser> getBeerinosByUser(IEnumerable<BeerinoUser> beerinos, int id)
        {
            return beerinos.Where(b => b.BeerinoByUser(id));
        }
    }
}
