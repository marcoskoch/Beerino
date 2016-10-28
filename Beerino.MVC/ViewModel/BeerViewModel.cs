using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class BeerViewModel
    {
        [Key]
        public int BeerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Revenue { get; set; }
        public bool Public { get; set; }
        public int UserID { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual IEnumerable<BeerinoUserViewModel> Beerinos { get; set; }
        public virtual IEnumerable<TaskBeerViewModel> TasksBeer { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}