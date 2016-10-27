using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class BeerinoUserViewModel
    {
        [Key]
        public int BeerinoUserID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public virtual UserViewModel User { get; set; }
        public int? BeerID { get; set; }
        public virtual BeerViewModel Beer { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}