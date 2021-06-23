using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.ViewModels;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Test.ViewModels
{
    [TestClass]
    public class HistoricoOrdemViewModelTest
    {
        private HistoricoOrdemViewModel _viewModel;

        [TestInitialize]
        public void OrdemMockTestInitialize()
        {
            _viewModel = new HistoricoOrdemViewModel();
        }

        [TestMethod]
        public void IncluirOrdem_TotalQuantidade_DeveSer_IgualASomaQuantidade()
        {
            for (int i = 0; i < 150; i++)
                _viewModel.IncluirOrdem();

            Assert.AreEqual(_viewModel.OrdemCollection.Sum(x => x.Quantidade), _viewModel.TotalQuantidade);
        }

        [TestMethod]
        public void IncluirOrdem_TotalQuantidadeDisponivel_DeveSer_IgualATotalQuantidade()
        {
            for (int i = 0; i < 150; i++)
                _viewModel.IncluirOrdem();

            Assert.AreEqual(_viewModel.TotalQuantidade, _viewModel.TotalQuantidadeDisponivel);
        }

        [TestMethod]
        public void Inicializar_OrdemCollection_Contagem_DeveSer_IgualA0()
        {
            Assert.IsTrue(_viewModel.OrdemCollection?.Count == 0);
        }

        [TestMethod]
        public void IncluirOrdem_OrdemCollection_Contagem_DeveSer_MaiorQue0()
        {
            _viewModel.IncluirOrdem();
            Assert.IsTrue(_viewModel.OrdemCollection?.Count > 0);
        }

        [TestMethod]
        public void AlterarOrdem_OrdemCollection_QuantidadeExecutada_DeveSer_MaiorQue0()
        {
            for (int i = 0; i < 150; i++)
                _viewModel.IncluirOrdem();

            var quantidadeOrdensAntesAlterar = _viewModel.OrdemCollection.Count;
            var somaQuantidadeExecutadaAntesAlterar = _viewModel.OrdemCollection.Sum(ordem => ordem.QuantidadeExecutada);

            for (int i = 0; i < 150; i++)
                _viewModel.AlterarOrdem();

            var quantidadeOrdensAposAlterar = _viewModel.OrdemCollection.Count;
            var somaQuantidadeExecutadaAposAlterar = _viewModel.OrdemCollection.Sum(ordem => ordem.QuantidadeExecutada);

            Assert.IsTrue(quantidadeOrdensAntesAlterar != quantidadeOrdensAposAlterar || (somaQuantidadeExecutadaAntesAlterar == 0 && somaQuantidadeExecutadaAposAlterar > 0));
        }
    }
}
