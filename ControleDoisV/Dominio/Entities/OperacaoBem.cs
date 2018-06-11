using Dominio.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dominio.Entities
{
    public class OperacaoBem : Entity
    {
        [Display(Name ="ID")]
        public long OperacaoBemID { get; set; }

        [Display(Name ="Tipo de Operação")]
        [Required]
        public TipoOperacaoBem TipoOperacaoBem { get; set; }

        [Display(Name ="Data da Operação")]
        [DataType(DataType.DateTime)]
        public DateTime? Data { get; set; }

        public Bem Bem { get; set; }

        public Pessoa Tomador { get; set; }

        public void EfetivarOperacao()
        {
            if (TipoOperacaoBem == TipoOperacaoBem.Emprestimo)
            {
                if (Bem.Status == Status.Inativo)
                    throw new Exception("O bem Inativo não pode ser emprestado, pois ele já esta emprestado");

                Bem.Desativar();
            }
            else
            {
                if (Bem.Status == Status.Ativo)
                    throw new Exception("Não é possivel Devolver um Bem Ativo");

                Bem.Ativar();
            }

        }

        [Display(Name ="Observação")]
        public string Observacao { get; set; }
    }
}
