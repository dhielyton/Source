using Dominio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Enumeration;
namespace ControleDoisV.TestUnit.Dominio
{
    [TestClass]
    public class BemTest
    {
        [TestMethod]
        public void CriarBem()
        {
            Bem bem = Criar("BATTLEFIELD 4 PS3", "JOGOS");
            
            Assert.IsNotNull(bem);
            Assert.AreEqual(bem.Status, Status.Ativo);
            Assert.IsNotNull(bem.Descricao);
            Assert.IsNotNull(bem.GrupoBem);
        }

        public static Bem Criar(string descricaoBem, string descricaoGrupo)
        {
            Bem bem = new Bem();
            bem.Descricao = descricaoBem;
            bem.GrupoBem = new GrupoBem { Descricao = descricaoGrupo };
            return bem;
        }
    }
}
