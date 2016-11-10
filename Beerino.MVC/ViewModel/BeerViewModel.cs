using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class BeerViewModel
    {
        [Key]
        public int BeerID { get; set; }

        [DisplayName("Nome da Cerveja")]
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Receita")]
        [Required(ErrorMessage = "Preencha o campo Receita")]
        [DataType(DataType.MultilineText)]
        public string Revenue { get; set; }

        [ScaffoldColumn(false)]
        public bool Public { get; set; }

        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual IEnumerable<BeerinoUserViewModel> Beerinos { get; set; }
        public virtual IEnumerable<TaskBeerViewModel> TasksBeer { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}