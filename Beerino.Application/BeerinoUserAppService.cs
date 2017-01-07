using System;
using System.Collections.Generic;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Application
{
    public class BeerinoUserAppService : AppServiceBase<BeerinoUser>, IBeerinoUserAppService
    {
        private readonly IBeerinoUserService _beerinoUserService;

        public BeerinoUserAppService(IBeerinoUserService beerinoUserService) 
            : base(beerinoUserService)
        {
            _beerinoUserService = beerinoUserService;
        }

        public IEnumerable<BeerinoUser> getBeerinoByUser(int id)
        {
            return _beerinoUserService.getBeerinosByUser(_beerinoUserService.GetAll(), id);
        }
    }
}
