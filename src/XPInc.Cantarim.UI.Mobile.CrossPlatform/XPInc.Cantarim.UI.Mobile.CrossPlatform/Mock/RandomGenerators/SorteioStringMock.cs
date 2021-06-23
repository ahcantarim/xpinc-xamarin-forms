using System;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators
{
    /// <summary>
    /// Classe auxiliar para sortear valores possíveis de uma String delimitada por um separador informado.
    /// </summary>
    public static class SorteioStringMock
    {
        #region Métodos públicos

        /// <summary>
        /// Escolhe um valor aleatório dentro de uma String separada pelo caractere informado (vírgula por padrão).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PickRandomValue(this string value, char separator = ',')
        {
            var random = new Random();
            var values = value.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            return values[random.Next(values.Length)];
        }

        #endregion
    }
}
