using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entities
{
    public class Pessoa:Entity
    {
        [Display(Name ="ID")]
        public int PessoaID { get; set; }
        [Required]
        public string Nome { get; set; }

        [Display(Name ="Observação")]
        public string Observacao { get; set; }
    }
}
