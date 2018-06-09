using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Bem:Entity
    {
        public Bem()
        {
            Status = Status.Ativo;
        }
        public long BemId { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

        public string Observacao { get; set; }
    }
}
