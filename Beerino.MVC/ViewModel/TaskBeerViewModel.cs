using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class TaskBeerViewModel
    {
        [Key]
        public int TaskBeerID { get; set; }
        public int Time { get; set; }
        public int Temperature { get; set; }
        public int Order { get; set; }
        public int BeerID { get; set; }
        public virtual BeerViewModel Beer { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}