using Dominio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Enumeration;
namespace ControleDoisV.TestUnit
{
    [TestClass]
    public class BemTest
    {
        [TestMethod]
        public void CriarBem()
        {
            Bem bem = new Bem();
            bem.Descricao = "BATTLEFIELD 4 PS3";
            Assert.IsNotNull(bem);
            Assert.AreEqual(bem.Status, Status.Ativo);
            Assert.IsNotNull(bem.Descricao);
        }
    }
}
