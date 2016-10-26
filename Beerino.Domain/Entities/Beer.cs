using System.Collections.Generic;

namespace Beerino.Domain.Entities
{
    public class Beer : EntityBase
    {
        public int BeerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Revenue { get; set; }
        public bool Public { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<BeerinoUser> Beerinos { get; set; }
        public virtual IEnumerable<TaskBeer> TasksBeer { get; set; }
    }
}
