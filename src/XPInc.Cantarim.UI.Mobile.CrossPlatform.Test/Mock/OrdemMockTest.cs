using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Models;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Test.Mock
{
    [TestClass]
    public class OrdemMockTest
    {
        private OrdemModel _ordemModel;

        [TestInitialize]
        public void OrdemMockTestInitialize()
        {
            _ordemModel = OrdemMock.SimularCriacaoOrdem();
        }

        [TestMethod]
        public void CriarOrdem_Assessor_DeveExistir()
        {
            Assert.IsTrue(ConfigMock.MOCK_ASSESSORES.Contains(_ordemModel.Assessor));
        }

        [TestMethod]
        public void CriarOrdem_Ativo_DeveExistir()
        {
            Assert.IsTrue(ConfigMock.MOCK_ATIVOS.Contains(_ordemModel.Ativo));
        }

        [TestMethod]
        public void CriarOrdem_Tipo_DeveExistir()
        {
            Assert.IsTrue(ConfigMock.MOCK_TIPO_ORDEM.Contains(_ordemModel.Tipo));
        }

        [TestMethod]
        public void CriarOrdem_Quantidade_DeveExistir()
        {
            Assert.IsTrue(ConfigMock.MOCK_QUANTIDADE_LOTE_PADRAO.Contains(_ordemModel.Quantidade.ToString()));
        }

        [TestMethod]
        public void CriarOrdem_QuantidadeDisponivel_DeveSer_IgualAQuantidade()
        {
            Assert.AreEqual(_ordemModel.Quantidade, _ordemModel.QuantidadeDisponivel);
        }

        [TestMethod]
        public void CriarOrdem_QuantidadeExecutada_DeveSer_IgualA0()
        {
            Assert.AreEqual(0, _ordemModel.QuantidadeExecutada);
        }

        [TestMethod]
        public void CriarOrdem_Valor_DeveSer_MaiorQue0()
        {
            Assert.AreNotEqual(0, _ordemModel.Valor);
        }

        [DataTestMethod]
        [DataRow(0)]
        public void VerificarAcaoRealizar_DeveSer_IgualAIncluir_Quando_QuantidadeIgualA0(int quantidadeAtualOrdens)
        {
            var actual = OrdemMock.VerificarAcaoRealizar(quantidadeAtualOrdens);
            Assert.AreEqual(EAcaoHistoricoOrdem.Incluir, actual);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        public void VerificarAcaoRealizar_DeveSer_IgualAIncluirOuAlterarOuAmbos_Quando_QuantidadeMaiorQue0(int quantidadeAtualOrdens)
        {
            var actual = OrdemMock.VerificarAcaoRealizar(quantidadeAtualOrdens);
            Assert.IsTrue(actual == EAcaoHistoricoOrdem.Incluir || 
                          actual == EAcaoHistoricoOrdem.Alterar || 
                          actual == EAcaoHistoricoOrdem.Ambos);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void VerificarCargaTrabalho_DeveSer_IgualANormal_Quando_QuantidadeMenorOuIgualA1(int quantidadeAtualOrdens)
        {
            var actual = OrdemMock.VerificarCargaTrabalho(quantidadeAtualOrdens);
            Assert.AreEqual(ENivelCargaTrabalho.Normal, actual);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void ObterQuantidadeOrdensAlterar_DeveSer_IgualA1_Quando_QuantidadeMenorOuIgualA1(int quantidadeAtualOrdens)
        {
            var actual = OrdemMock.ObterQuantidadeOrdemSimular(quantidadeAtualOrdens);
            Assert.AreEqual(1, actual);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        [DataRow(30)]
        [DataRow(40)]
        [DataRow(50)]
        public void ObterQuantidadeOrdensAlterar_DeveSer_MenorOuIgualAQuantidade_Quando_QuantidadeMaiorQue1(int quantidadeAtualOrdens)
        {
            var actual = OrdemMock.ObterQuantidadeOrdemSimular(quantidadeAtualOrdens);
            Assert.IsTrue(actual <= quantidadeAtualOrdens);
        }
    }
}
