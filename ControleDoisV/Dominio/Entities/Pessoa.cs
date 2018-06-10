using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Pessoa:Entity
    {
        public int PessoaID { get; set; }

        public string Nome { get; set; }

        public string Observacao { get; set; }
    }
}
