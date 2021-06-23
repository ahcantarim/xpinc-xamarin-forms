using System;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators
{
    /// <summary>
    /// Classe genérica para sortear valores aleatórios para teste de Histórico de Ordens.
    /// </summary>
    public static class SorteioOrdemMock
    {
        #region Métodos públicos

        /// <summary>
        /// Sorteia aleatoriamente um nome de assessor, entre os valores pré-definidos.
        /// </summary>
        /// <returns></returns>
        public static string DrawAssessor()
        {
            return SorteioStringMock.PickRandomValue(ConfigMock.MOCK_ASSESSORES);
        }

        /// <summary>
        /// Sorteia aleatoriamente um número de conta.
        /// </summary>
        /// <returns></returns>
        public static string DrawConta()
        {
            var random = new Random();
            return random.Next(0, 100000).ToString("D6");
        }

        /// <summary>
        /// Sorteia aleatoriamente um ticker de ativo, entre os valores pré-definidos.
        /// </summary>
        /// <returns></returns>
        public static string DrawAtivo()
        {
            return SorteioStringMock.PickRandomValue(ConfigMock.MOCK_ATIVOS);
        }

        /// <summary>
        /// Sorteia aleatoriamente um tipo de operação, entre os valores pré-definidos.
        /// </summary>
        /// <returns></returns>
        public static string DrawTipo()
        {
            return SorteioStringMock.PickRandomValue(ConfigMock.MOCK_TIPO_ORDEM);
        }

        /// <summary>
        /// Sorteia aleatoriamente uma quantidade de compra/venda, entre os valores pré-definidos.
        /// </summary>
        /// <returns></returns>
        public static int DrawQuantidadeLotePadrao()
        {
            return Convert.ToInt32(SorteioStringMock.PickRandomValue(ConfigMock.MOCK_QUANTIDADE_LOTE_PADRAO));
        }

        /// <summary>
        /// Sorteia aleatoriamente uma quantidade de execução, entre 1 e 900, para ser adicionada à execução da ordem.
        /// </summary>
        /// <returns></returns>
        public static int DrawQuantidadeLoteFracionario()
        {
            var random = new Random();
            return random.Next(1, 901);
        }

        /// <summary>
        /// Sorteia aleatoriamente um valor (preço), entre os valores pré-definidos.
        /// </summary>
        /// <returns></returns>
        public static double DrawValor()
        {
            var random = new Random();

            var valuesFixed = new double[] { 1, 2, 4, 8, 16, 32, 64 };
            var chosenFixed = valuesFixed[random.Next(valuesFixed.Length)];

            var valuesFloating = new double[] { .0, .10, .25, .50, .75, .90 };
            var chosenFloating = valuesFloating[random.Next(valuesFloating.Length)];

            return Math.Round(chosenFixed + chosenFloating, 2);
        }

        #endregion
    }
}
