using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            // Inicializa o Xamarin.Forms.
            Forms.Init();
            
            // Registra a coleção de serviços da plataforma compartilhada.
            CrossPlatform.App.BuildContainerServiceProvider();

            // Carrega a aplicação criada no projeto .NET Standard.
            LoadApplication(new CrossPlatform.App());
        }
    }
}
