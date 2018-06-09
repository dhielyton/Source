using Dominio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Enumeration;
namespace ControleDoisV.TestUnit.Dominio
{
    [TestClass]
    public class GrupoBemTest
    {
        [TestMethod]
        public void CriarGrupoBem()
        {
            GrupoBem grupoBem = new GrupoBem();
            grupoBem.Descricao = "JOGOS PS3";
            Assert.IsNotNull(grupoBem);
            Assert.AreEqual(grupoBem.Status, Status.Ativo);
            Assert.IsNotNull(grupoBem.Descricao);
        }
    }
}
