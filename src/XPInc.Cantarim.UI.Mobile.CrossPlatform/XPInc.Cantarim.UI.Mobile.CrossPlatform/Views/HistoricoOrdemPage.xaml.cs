using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPInc.Cantarim.UI.Mobile.CrossPlatform.ViewModels;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Views
{
    [ExcludeFromCodeCoverage]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class HistoricoOrdemPage : ContentPage
    {
        private HistoricoOrdemViewModel ViewModel => BindingContext as HistoricoOrdemViewModel;

        public HistoricoOrdemPage()
        {
            InitializeComponent();

            BindingContext = App.ServiceProvider.GetService<HistoricoOrdemViewModel>();
            ViewModel.IniciarCronometroCommand.Execute(null);
        }
    }
}