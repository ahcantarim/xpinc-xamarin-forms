using System;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.RandomGenerators;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Models
{
    public class OrdemModel
    {
        #region Estados

        public DateTime DataHora { get; private set; }

        public string Assessor { get; private set; }

        public string Conta { get; private set; }

        public string Ativo { get; private set; }

        public string Tipo { get; private set; }

        public int Quantidade { get; private set; }

        public int QuantidadeDisponivel => Quantidade - QuantidadeExecutada;

        public int QuantidadeExecutada { get; private set; }

        public double Valor { get; private set; }

        #endregion

        #region Comportamentos

        /// <summary>
        /// Simula uma alteração de quantidade executada de forma aleatória (incrementando o valor atual).
        /// </summary>
        public void SimularAlteracaoQuantidadeExecutada()
        {
            QuantidadeExecutada += SorteioOrdemMock.DrawQuantidadeLoteFracionario();

            if (QuantidadeExecutada > Quantidade)
                QuantidadeExecutada = Quantidade;
        }

        #endregion

        #region Construtores

        public OrdemModel(string assessor, string conta, string ativo, string tipo, int quantidade, double valor)
        {
            DataHora = DateTime.Now;
            Assessor = assessor;
            Conta = conta;
            Ativo = ativo;
            Tipo = tipo;
            Quantidade = quantidade;
            QuantidadeExecutada = 0;
            Valor = valor;
        }

        #endregion
    }
}
