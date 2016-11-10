﻿using System;
using System.Collections.Generic;
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;
using System.Linq;

namespace Beerino.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public int GetIdByEmail(string email)
        {
            return _userRepository.GetIdByEmail(email);
        }

        public IEnumerable<User> getSpecialUsers(IEnumerable<User> users)
        {
            return users.Where(u => u.SpecialUser(u));
        }
    }
}
