using MvvmHelpers;
using PropertyChanged;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Mock.Enumerations;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Models;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HistoricoOrdemViewModel
    {
        #region Atributos

        private ConcurrentDictionary<string, OrdemModel> _ordemDictionary { get; set; } = new ConcurrentDictionary<string, OrdemModel>();

        #endregion

        #region Propriedades

        public ObservableRangeCollection<OrdemModel> OrdemCollection { get; set; } = new ObservableRangeCollection<OrdemModel>();

        public int TotalQuantidade { get; set; }

        public int TotalQuantidadeDisponivel { get; set; }

        #endregion

        #region Comandos

        [ExcludeFromCodeCoverage]
        public ICommand IniciarCronometroCommand => new Command(() => ExecutarIniciarCronometroCommand());

        #endregion

        #region Métodos privados

        [ExcludeFromCodeCoverage]
        private void ExecutarIniciarCronometroCommand()
        {
            try
            {
                Task.Run(async () =>
                   {
                       while (true)
                       {
                           Device.BeginInvokeOnMainThread(() =>
                           {
                               SimularAlteracaoHistoricoOrdem();
                           });


                           // Força a coleta de lixo para tentar recuperar toda a memória que estiver inacessível.
                           GC.Collect();

                           // Aguarda um tempo em milissegundos até a execução da rotina novamente.
                           await Task.Delay(TimeSpan.FromMilliseconds(ConfigMock.INTERVALO_ATUALIZACAO_MILISSEGUNDOS));
                       }
                   });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"   >>>> ERRO ExecutarIniciarCronometroCommand: {ex.Message}");
            }
        }

        /// <summary>
        /// Define qual ação deverá ser executada ma simulação. Pode incluir uma ordem e/ou alterar ordens existentes.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void SimularAlteracaoHistoricoOrdem()
        {
            switch (OrdemMock.VerificarAcaoRealizar(_ordemDictionary.Count))
            {
                case EAcaoHistoricoOrdem.Incluir:
                    IncluirOrdem();
                    break;

                case EAcaoHistoricoOrdem.Alterar:
                    AlterarOrdem();
                    break;

                case EAcaoHistoricoOrdem.Ambos:
                    IncluirOrdem(false);
                    IncluirOrdem(false);
                    AlterarOrdem(false);
                    IncluirOrdem(false);
                    AtualizarQuantidadesTotais();
                    break;
            }
        }

        /// <summary>
        /// Atualiza as propriedades que são utilizadas para renderizar a tela da aplicação.
        /// </summary>
        private void AtualizarQuantidadesTotais()
        {
            TotalQuantidade = _ordemDictionary.Sum(ordem => ordem.Value.Quantidade);
            TotalQuantidadeDisponivel = _ordemDictionary.Sum(ordem => ordem.Value.QuantidadeDisponivel);

            // Para renderizar na tela, considera apenas as ordens que ainda não foram totalmente executadas (possuem quantidade disponível).
            OrdemCollection.ReplaceRange(_ordemDictionary.Where(x => x.Value.QuantidadeDisponivel > 0).Select(x => x.Value));
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Inclui uma nova ordem aleatória no dicionário de dados.
        /// </summary>
        /// <param name="forceBindingRefresh"></param>
        public void IncluirOrdem(bool forceBindingRefresh = true)
        {
            _ordemDictionary.TryAdd(Guid.NewGuid().ToString(), OrdemMock.SimularCriacaoOrdem());

            if (forceBindingRefresh)
            {
                AtualizarQuantidadesTotais();
            }
        }

        /// <summary>
        /// Altera uma ou mais ordens aleatórias do dicionário de dados.
        /// </summary>
        /// <param name="forceBindingRefresh"></param>
        public void AlterarOrdem(bool forceBindingRefresh = true)
        {
            var totalOrdens = _ordemDictionary.Count;

            if (totalOrdens == 0)
                return;

            var quantidadeOrdemAlterar = OrdemMock.ObterQuantidadeOrdemSimular(totalOrdens);

            for (int index = 0; index < quantidadeOrdemAlterar; index++)
            {
                // Define um índice aleatório de ordem no dicionário de dados, para simular alteração do item correspondente.
                var random = new Random();
                var chosenIndex = random.Next(0, _ordemDictionary.Count);

                var ordemAtual = _ordemDictionary.ElementAt(chosenIndex);
                ordemAtual.Value.SimularAlteracaoQuantidadeExecutada();

                // Se a ordem foi totalmente executada (não há mais quantidade disponível), o item é removido do dicionário de dados.
                if (ordemAtual.Value.QuantidadeDisponivel == 0)
                {
                    _ordemDictionary.TryRemove(ordemAtual.Key, out _);
                }
            }

            if (forceBindingRefresh)
            {
                AtualizarQuantidadesTotais();
            }

#if DEBUG
            // Para análise de carga de trabalho.
            System.Diagnostics.Debug.WriteLine($"   >> ORDENS ► Total anterior: {totalOrdens} / Alteradas: {quantidadeOrdemAlterar} / Total atual: {_ordemDictionary.Count}");
#endif
        }

        #endregion
    }
}
