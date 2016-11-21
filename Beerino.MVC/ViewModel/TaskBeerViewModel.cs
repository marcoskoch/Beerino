using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class TaskBeerViewModel
    {
        [Key]
        public int TaskBeerID { get; set; }

        [DisplayName("Tempo")]
        [Required(ErrorMessage = "Preencha o campo Tempo")]
        public int Time { get; set; }

        [DisplayName("Temperatura")]
        [Required(ErrorMessage = "Preencha o campo Temperatura")]
        public int Temperature { get; set; }

        [DisplayName("Ordem")]
        [Required(ErrorMessage = "Preencha o campo Ordem")]
        public int Order { get; set; }
        
        [DisplayName("Cerveja")]
        public int BeerID { get; set; }
        public virtual BeerViewModel Beer { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}