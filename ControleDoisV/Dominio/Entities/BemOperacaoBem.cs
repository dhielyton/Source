using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class BemOperacaoBem
    {
        public long BemID { get; set; }
        public Bem Bem { get; set; }

        public long OperacaoBemID { get; set; }
        public OperacaoBem OperacaoBem { get; set; }

        public static BemOperacaoBem Create(Bem bem, OperacaoBem operacaoBem)
        {
            return new BemOperacaoBem { Bem = bem, BemID = bem.BemID, OperacaoBem = operacaoBem, OperacaoBemID = operacaoBem.OperacaoBemID };
        }
    }
}
