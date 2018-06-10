using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class GrupoBem:Entity
    {
        public long GrupoBemID { get; set; }

        public string Descricao { get; set; }
    }
}
