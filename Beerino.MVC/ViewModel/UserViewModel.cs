﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Beerino.MVC.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual IEnumerable<BeerinoUserViewModel> Beerinos { get; set; }
        public virtual IEnumerable<BeerViewModel> Beers { get; set; }

        [DisplayName("Disponível?")]
        public bool Active { get; set; }
    }
}