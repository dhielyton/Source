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

        public virtual ICollection<BemOperacaoBem> Bens { get; set; }

        public Pessoa Tomador { get; set; }

        public void AddBem(Bem bem)
        {
            Bens = Bens ?? new List<BemOperacaoBem>();
            if (Bens.Where(x => x.BemID == bem.BemID).Count() > 0)
                throw new Exception("O Bem já está adicionado a operação");

            if (TipoOperacaoBem == TipoOperacaoBem.Emprestimo)
            {
                if (bem.Status == Status.Inativo)
                    throw new Exception("O bem Inativo não pode ser emprestado, pois ele já esta emprestado");

                bem.Desativar();
            }
            else
            {
                if (bem.Status == Status.Ativo)
                    throw new Exception("Não é possivel Devolver um Bem Ativo");

                bem.Ativar();
            }

            Bens.Add(BemOperacaoBem.Create(bem,this));

        }
        [Display(Name ="Observação")]
        public string Observacao { get; set; }
    }
}
