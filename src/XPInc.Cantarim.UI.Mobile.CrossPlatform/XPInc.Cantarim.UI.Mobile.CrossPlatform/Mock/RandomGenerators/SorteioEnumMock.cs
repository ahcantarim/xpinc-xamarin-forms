using System;
using System.Linq;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators
{
    /// <summary>
    /// Classe genérica para sortear valores possíveis de um Enum sequencial.
    /// </summary>
    /// <typeparam name="T">Enum a ser considerado.</typeparam>
    public static class SorteioEnumMock<T> where T : Enum
    {
        #region Métodos públicos

        /// <summary>
        /// Gera um valor possível para o Enum informado, considerando seus valores mínimo e máximo.
        /// </summary>
        /// <returns>Valor existente no Enum informado.</returns>
        public static T GenerateRandomValue()
        {
            // Obtém os valores do Enum informado para a classe genérica.
            var values = Enum.GetValues(typeof(T)).Cast<int>();

            // Sorteia um número entre os valores mínimo e máximo do Enum informado.
            var random = new Random();
            var chosen = random.Next(values.Min(), values.Max() + 1);

            // Retorna o valor sorteado, já convertido para o tipo do Enum informado.
            return (T)Enum.Parse(typeof(T), chosen.ToString());
        }

        #endregion
    }
}
