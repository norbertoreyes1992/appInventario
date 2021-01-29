using appInventario.ViewModel;
using Xamarin.Forms;

namespace appInventario
{
    public partial class MainPage : ContentPage
    {
        public paginaPrincipalViewModel vmMainPage { get; set; }
        public MainPage()
        {
            InitializeComponent();
            vmMainPage = new paginaPrincipalViewModel(Navigation);
            BindingContext = vmMainPage;
        }
    }
}
