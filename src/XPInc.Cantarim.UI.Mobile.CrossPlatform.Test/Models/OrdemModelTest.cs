using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Models;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Test.Models
{
    [TestClass]
    public class OrdemModelTest
    {
        private OrdemModel _model;

        [TestInitialize]
        public void OrdemMockTestInitialize()
        {
            _model = OrdemMock.SimularCriacaoOrdem();
        }

        [TestMethod]
        public void Alterar_QuantidadeExecutada_DeveSer_MaiorQue0EMenorOuIgualAQuantidade()
        {
            for (int i = 0; i < 5; i++)
                _model.SimularAlteracaoQuantidadeExecutada();

            Assert.IsTrue(_model.QuantidadeExecutada > 0 && 
                          _model.QuantidadeExecutada <= _model.Quantidade);
        }
    }
}
