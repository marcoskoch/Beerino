using System;
using System.Collections.Generic;

namespace Beerino.Domain.Entities
{
    public class User : EntityBase
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual IEnumerable<BeerinoUser> Beerinos { get; set; }
        public virtual IEnumerable<Beer> Beers { get; set; }

        public bool SpecialUser(User user)
        {
            return user.Active && DateTime.Now.Year - user.CreationDate.Year >= 5;
        }
    }
}
