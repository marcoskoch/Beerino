namespace Beerino.Domain.Entities
{
    public class BeerinoUser
    {
        public int BeerinoUserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Revenue { get; set; }
        public bool Public { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
