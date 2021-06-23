namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations
{
    /// <summary>
    /// Identifica a ação que será realizada pelo Mock.
    /// </summary>
    public enum EAcaoHistoricoOrdem
    {
        /// <summary>
        /// Indica que uma nova ordem deve ser incluída no histórico.
        /// </summary>
        Incluir = 1,

        /// <summary>
        /// Indica que uma ordem existente deve ser alterada no histórico.
        /// </summary>
        Alterar = 2,

        /// <summary>
        /// Indica que uma nova ordem deve ser incluída e que uma ordem existente deve ser alterada no histórico.
        /// </summary>
        Ambos = 3
    }
}
