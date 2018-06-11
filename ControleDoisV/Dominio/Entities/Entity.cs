using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entities
{
    public class Entity
    {
        public Entity()
        {
            Status = Status.Ativo;
        }

        [Display(Name ="Situação")]
        public Status Status { get; set; }

        public void Desativar()
        {
            Status = Status.Inativo;
        }

        public void Ativar()
        {
            Status = Status.Ativo;
        }
    }
}
