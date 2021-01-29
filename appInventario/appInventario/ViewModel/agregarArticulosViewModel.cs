using appInventario.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appInventario.ViewModel
{
    public class agregarArticulosViewModel: BaseViewModel
    {
        private articuloModel _mArticulo { get; set; }
        public Command agregarArticulo { get; set; }
        private INavigation nav { get; set; }

        public articuloModel mArticulo
        {
            get => _mArticulo;
            set
            {
                _mArticulo = value;
                OnPropertyChanged();
            }
        }

        public agregarArticulosViewModel(INavigation navigation )
        {
            nav = navigation;
            agregarArticulo = new Command(async () => await guardarArticulo());
            mArticulo = new articuloModel();
        }

        private async Task guardarArticulo()
        {
            if (!string.IsNullOrEmpty(mArticulo.sSkuArticulo))
            {
                if (!string.IsNullOrEmpty(mArticulo.sNombreArticulo))
                {
                    if (!string.IsNullOrEmpty(mArticulo.sDescripcionArt))
                    {
                        if (mArticulo.dPrecioArticulo > 0)
                        {
                            await App.dbBase.guardarArticulo(mArticulo);
                            await Application.Current.MainPage.DisplayAlert("Información", "Datos Guardados Con Exito", "Ok");
                            mArticulo = new articuloModel();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Información", "El precio debe ser mayor a 0", "Ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Información", "Favor de agregar una descripción", "Ok");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Información", "Favor de agregar un nombre al articulo", "Ok");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Información", "Favor de agregar un sku", "Ok");
            }
        }

    }
}
