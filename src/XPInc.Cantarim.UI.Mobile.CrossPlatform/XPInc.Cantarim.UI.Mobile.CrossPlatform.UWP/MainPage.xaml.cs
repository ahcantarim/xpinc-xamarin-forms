namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Registra a coleção de serviços da plataforma compartilhada.
            CrossPlatform.App.BuildContainerServiceProvider();

            // Carrega a aplicação criada no projeto .NET Standard.
            LoadApplication(new CrossPlatform.App());
        }
    }
}
