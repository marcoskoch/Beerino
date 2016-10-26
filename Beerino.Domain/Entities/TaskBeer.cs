namespace Beerino.Domain.Entities
{
    public class TaskBeer : EntityBase
    {
        public int TaskBeerID { get; set; }
        public int Time { get; set; }
        public int Temperature { get; set; }
        public int Order { get; set; }
        public int BeerID { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
