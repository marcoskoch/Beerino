using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Beerino.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService) 
            : base(userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> getSpecialUsers()
        {
            return _userService.getSpecialUsers(_userService.GetAll());
        }
    }
}
