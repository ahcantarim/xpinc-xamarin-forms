using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Test.Mock.RandomGenerators
{
    [TestClass]
    public class SorteioEnumMockTest
    {
        [TestMethod]
        public void GerarValorAleatorio_EAcaoHistoricoOrdem_DeveSer_MenorOuIgualA3()
        {
            var generatedValue = SorteioEnumMock<EAcaoHistoricoOrdem>.GenerateRandomValue();
            Assert.IsTrue((int)generatedValue <= 3);
        }

        [TestMethod]
        public void GerarValorAleatorio_ENivelCargaTrabalho_DeveSer_MenorOuIgualA2()
        {
            var generatedValue = SorteioEnumMock<ENivelCargaTrabalho>.GenerateRandomValue();
            Assert.IsTrue((int)generatedValue <= 2);
        }
    }
}
