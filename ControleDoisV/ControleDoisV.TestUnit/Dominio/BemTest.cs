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
            Bem bem = new Bem();
            bem.Descricao = "BATTLEFIELD 4 PS3";
            bem.GrupoBem = new GrupoBem { Descricao = "Jogos PS3" };
            Assert.IsNotNull(bem);
            Assert.AreEqual(bem.Status, Status.Ativo);
            Assert.IsNotNull(bem.Descricao);
            Assert.IsNotNull(bem.GrupoBem);
        }
    }
}
