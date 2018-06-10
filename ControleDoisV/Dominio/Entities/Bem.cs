using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Bem : Entity
    {
        public Bem()
        {

        }

        public long BemID { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public long GrupoBemID { get; set; }

        public GrupoBem GrupoBem { get; set; }

        public ICollection<BemOperacaoBem> Operacoes { get;  set; }
    }
}
