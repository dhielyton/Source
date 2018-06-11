using Dominio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Enumeration;
using System;

namespace ControleDoisV.TestUnit.Dominio
{
    [TestClass]
    public class OperacaoBemTest
    {
        [TestMethod]
        public void RealizarOperacaoEmprestimo()
        {
            var operacaoBem = new OperacaoBem();
            operacaoBem.TipoOperacaoBem = TipoOperacaoBem.Emprestimo;
            operacaoBem.Tomador = new Pessoa { Nome = "Wesley Ramon", Observacao = "Irmão" };
            operacaoBem.Data = DateTime.Now;
            var bem = BemTest.Criar("GOD OF WAR II", "Jogos PS2");
            operacaoBem.Bem = bem;
            operacaoBem.EfetivarOperacao();
            Assert.AreEqual(operacaoBem.TipoOperacaoBem, TipoOperacaoBem.Emprestimo);
            Assert.IsNotNull(operacaoBem.Tomador);
            Assert.AreEqual(operacaoBem.Bem.Status, Status.Inativo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RealizarOperacaoEmprestimoComBemInativo()
        {
            var operacaoBem = new OperacaoBem();
            operacaoBem.TipoOperacaoBem = TipoOperacaoBem.Emprestimo;
            operacaoBem.Tomador = new Pessoa { Nome = "Wesley Ramon", Observacao = "Irmão" };
            operacaoBem.Data = DateTime.Now;
            var bem = BemTest.Criar("GOD OF WAR II", "Jogos PS2");
            bem.Desativar();
            operacaoBem.Bem = bem;
            operacaoBem.EfetivarOperacao();

        }

        [TestMethod]
        public void RealizarOperacaoDevolucao()
        {
            var operacaoBem = new OperacaoBem();
            operacaoBem.TipoOperacaoBem = TipoOperacaoBem.Devolucao;
            operacaoBem.Tomador = new Pessoa { Nome = "Wesley Ramon", Observacao = "Irmão" };
            operacaoBem.Data = DateTime.Now;
            var bem = BemTest.Criar("GOD OF WAR II", "Jogos PS2");
            bem.Desativar();
            operacaoBem.Bem = bem;
            operacaoBem.EfetivarOperacao();

            Assert.AreEqual(operacaoBem.TipoOperacaoBem, TipoOperacaoBem.Devolucao);
            Assert.IsTrue(operacaoBem.Bem != null);
            Assert.IsNotNull(operacaoBem.Tomador);
            Assert.AreEqual(operacaoBem.Bem.Status, Status.Ativo);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RealizarOperacaoDevolucaoComBemAtivo()
        {
            var operacaoBem = new OperacaoBem();
            operacaoBem.TipoOperacaoBem = TipoOperacaoBem.Devolucao;
            operacaoBem.Tomador = new Pessoa { Nome = "Wesley Ramon", Observacao = "Irmão" };
            operacaoBem.Data = DateTime.Now;
            var bem = BemTest.Criar("GOD OF WAR II", "Jogos PS2");
            operacaoBem.Bem = bem;
            operacaoBem.EfetivarOperacao();
        }
    }
}
