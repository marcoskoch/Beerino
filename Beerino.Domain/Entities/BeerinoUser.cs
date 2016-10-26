namespace Beerino.Domain.Entities
{
    public class BeerinoUser : EntityBase
    {
        public int BeerinoUserID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int? BeerID { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
