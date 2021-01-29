using appInventario.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appInventario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmAgregarArticulos : ContentPage
    {
        public agregarArticulosViewModel vmAgregar { get; set; }
        public frmAgregarArticulos()
        {
            InitializeComponent();
            vmAgregar = new agregarArticulosViewModel(Navigation);
            BindingContext = vmAgregar;            
        }


        public async void tomarFoto()
        {
            var opciones = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "Foto.jpg",
                PhotoSize = PhotoSize.Medium,
                MaxWidthHeight = 400               
            };
            var foto = await CrossMedia.Current.TakePhotoAsync(opciones);

            if (foto != null)
            {

                imgArt.Source = ImageSource.FromStream(() =>
                {
                    var stream = foto.GetStream();
                    foto.Dispose();
                    return stream;
                });
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            tomarFoto();
        }
    }
}