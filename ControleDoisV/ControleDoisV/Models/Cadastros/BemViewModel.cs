using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Enumeration;

namespace ControleDoisV.Models.Cadastros
{
    public class BemViewModel
    {
        public BemViewModel(Bem bem)
        {
            _Bem = bem;
        }
        private Bem _Bem;

        public long ID
        {
            get { return _Bem.BemID; }
            set { _Bem.BemID = value; }
        }

        [Required]
        public Status Status
        {
            get { return _Bem.Status; }
            set { _Bem.Status = value; }
        }

        [Required]
        public string Descricao
        {
            get { return _Bem.Descricao; }
            set { _Bem.Descricao = value; }
        }

        public string Observacao
        {
            get { return _Bem.Observacao; }
            set { _Bem.Observacao = value; }
        }

    }
}
