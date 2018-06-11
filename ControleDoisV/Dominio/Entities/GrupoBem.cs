using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entities
{
    public class GrupoBem:Entity
    {
        [Display(Name ="ID")]
        public long GrupoBemID { get; set; }

        [Display(Name = "Descricao")]
        [Required]
        public string Descricao { get; set; }
    }
}
