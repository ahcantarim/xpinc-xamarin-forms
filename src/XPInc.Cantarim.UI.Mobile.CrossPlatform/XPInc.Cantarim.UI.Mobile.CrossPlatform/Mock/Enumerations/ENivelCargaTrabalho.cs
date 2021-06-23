namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations
{
    /// <summary>
    /// Identifica o nível de carga de trabalho que será realizada pelo Mock.
    /// </summary>
    public enum ENivelCargaTrabalho
    {
        /// <summary>
        /// Indica uma carga de trabalho normal, onde apenas uma ordem é criada ou modificada no momento.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Indica uma carga de trabalho alta, onde mais de uma ordem é modificada no momento.
        /// </summary>
        Alta = 2
    }
}
