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
            operacaoBem.AddBem(bem);
            Assert.AreEqual(operacaoBem.TipoOperacaoBem, TipoOperacaoBem.Emprestimo);
            Assert.IsTrue(operacaoBem.Bens.Count > 0);
            Assert.IsNotNull(operacaoBem.Tomador);
            foreach(var item in operacaoBem.Bens)
            {
                Assert.AreEqual(item.Status, Status.Inativo);
            }
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
            operacaoBem.AddBem(bem);
            
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
            operacaoBem.AddBem(bem);
            
            Assert.AreEqual(operacaoBem.TipoOperacaoBem, TipoOperacaoBem.Devolucao);
            Assert.IsTrue(operacaoBem.Bens.Count > 0);
            Assert.IsNotNull(operacaoBem.Tomador);
            foreach (var item in operacaoBem.Bens)
            {
                Assert.AreEqual(item.Status, Status.Ativo);
            }
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
           
            operacaoBem.AddBem(bem);
        }
    }
}
