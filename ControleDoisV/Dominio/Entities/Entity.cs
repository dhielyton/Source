using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Entity
    {
        public Entity()
        {
            Status = Status.Ativo;
        }

        public Status Status { get; set; }
    }
}
