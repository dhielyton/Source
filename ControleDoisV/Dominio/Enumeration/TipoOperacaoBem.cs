using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dominio.Enumeration
{
    public enum TipoOperacaoBem
    {
        [Description("Empréstimo")]
        Emprestimo,
        [Description("Devolução")]
        Devolucao
    }
}
