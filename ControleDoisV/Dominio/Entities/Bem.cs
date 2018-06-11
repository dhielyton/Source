using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entities
{
    public class Bem : Entity
    {
        public Bem()
        {

        }
        [Display(Name ="ID")]
        public long BemID { get; set; }

        [Display(Name ="Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name ="Observação")]
        public string Observacao { get; set; }

        public long GrupoBemID { get; set; }
        [Display(Name ="Grupo")]
        public GrupoBem GrupoBem { get; set; }

        public ICollection<BemOperacaoBem> Operacoes { get;  set; }
    }
}
