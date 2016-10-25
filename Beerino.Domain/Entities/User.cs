using System;
using System.Collections.Generic;

namespace Beerino.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegister { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<BeerinoUser> Beerinos { get; set; }

        public bool SpecialUser(User user)
        {
            return user.Active && DateTime.Now.Year - user.DateOfRegister.Year >= 5;
        }
    }
}
