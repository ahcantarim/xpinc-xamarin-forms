using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.Extensions;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform
{
    [ExcludeFromCodeCoverage]
    public partial class App : Xamarin.Forms.Application
    {
        #region Propriedades

        /// <summary>
        /// Provedor de serviços para injeção de dependência.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão para inicializar o aplicativo na plataforma compartilhada e definir a página inicial.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new Views.HistoricoOrdemPage();
        }

        #endregion

        #region Métodos públicos

        public static void BuildContainerServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.BatchAddTransient(Assembly.GetExecutingAssembly()
                                               .GetTypes()
                                               .Where(t => t.Namespace == "XPInc.Cantarim.UI.Mobile.CrossPlatform.ViewModels" 
                                                        && t.Name.EndsWith("ViewModel"))
                                               .ToList());

            ServiceProvider = services.BuildServiceProvider();
        }

        #endregion
    }
}
