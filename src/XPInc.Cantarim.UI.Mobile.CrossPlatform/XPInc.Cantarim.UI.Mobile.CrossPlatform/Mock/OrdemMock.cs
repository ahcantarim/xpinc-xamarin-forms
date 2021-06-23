using System;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock
{
    /// <summary>
    /// Classe auxiliar para geração do Mock.
    /// </summary>
    public static class OrdemMock
    {
        #region Métodos públicos

        /// <summary>
        /// Cria uma nova ordem aleatória.
        /// </summary>
        /// <returns>Instância do objeto criado.</returns>
        public static Models.OrdemModel SimularCriacaoOrdem()
        {
            return new Models.OrdemModel(SorteioOrdemMock.DrawAssessor(),
                                         SorteioOrdemMock.DrawConta(),
                                         SorteioOrdemMock.DrawAtivo(),
                                         SorteioOrdemMock.DrawTipo(),
                                         SorteioOrdemMock.DrawQuantidadeLotePadrao(),
                                         SorteioOrdemMock.DrawValor());
        }

        /// <summary>
        /// Define qual ação deverá ser realizada pela aplicação.
        /// </summary>
        /// <param name="quantidadeAtualOrdens">Quantidade atual de ordens no histórico.</param>
        /// <returns></returns>
        public static EAcaoHistoricoOrdem VerificarAcaoRealizar(int quantidadeAtualOrdens)
        {
            if (quantidadeAtualOrdens == 0)
                return EAcaoHistoricoOrdem.Incluir;
            else
                return SorteioEnumMock<EAcaoHistoricoOrdem>.GenerateRandomValue();
        }

        /// <summary>
        /// Define qual carga de trabalho será realizada pela aplicação.
        /// </summary>
        /// <param name="quantidadeAtualOrdens">Quantidade atual de ordens no histórico.</param>
        /// <returns></returns>
        public static ENivelCargaTrabalho VerificarCargaTrabalho(int quantidadeAtualOrdens)
        {
            if (quantidadeAtualOrdens <= 1)
                return ENivelCargaTrabalho.Normal;
            else
                return SorteioEnumMock<ENivelCargaTrabalho>.GenerateRandomValue();
        }

        /// <summary>
        /// Define a quantidade de ordens que serão modificadas pela aplicação.
        /// </summary>
        /// <param name="quantidadeAtualOrdens">Quantidade atual de ordens no histórico.</param>
        /// <returns></returns>
        public static int ObterQuantidadeOrdemSimular(int quantidadeAtualOrdens)
        {
            if (VerificarCargaTrabalho(quantidadeAtualOrdens) == ENivelCargaTrabalho.Normal)
            {
                return 1;
            }
            else
            {
                var random = new Random();
                return random.Next(1, quantidadeAtualOrdens + 1);
            }
        }

        #endregion
    }
}
