using System.Diagnostics.CodeAnalysis;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock
{
    /// <summary>
    /// Classe auxiliar para configuração do Mock.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigMock
    {
        #region Constantes

        public const int INTERVALO_ATUALIZACAO_MILISSEGUNDOS = 50;

        public const string MOCK_ASSESSORES = "-,Igor,Philipe,Eduardo,Marina,André,Rafael,Angelo,Arthur";

        public const string MOCK_ATIVOS = "ABEV3,LEVE3,LREN3,EGIE3,MDIA3,ITSA4,PSSA3,FLRY3,B3SA3,SAPR4";

        public const string MOCK_TIPO_ORDEM = "C,V";

        public const string MOCK_QUANTIDADE_LOTE_PADRAO = "100,200,300,400,500,600,700,800,900";

        #endregion
    }
}
