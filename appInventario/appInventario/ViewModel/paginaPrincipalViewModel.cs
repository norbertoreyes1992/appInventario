using appInventario.Models;
using appInventario.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appInventario.ViewModel
{
    public class paginaPrincipalViewModel: BaseViewModel
    {
        public Command refresarArticulos { get; set; }
        public Command SearchCommand { get; set; }
        public Command abrirVentana { get; set; }
        public INavigation nav { get; set; }

        private ObservableCollection<articuloModel> _listaArticulos;
        private ObservableCollection<articuloModel> _ArticulosBuscador;

        public ObservableCollection<articuloModel> listaArticulos
        {
            get => _listaArticulos;
            set
            {
                _listaArticulos = value;
                OnPropertyChanged("listaArticulos");
            }
        }
        public ObservableCollection<articuloModel> ArticulosBuscador
        {
            get => _ArticulosBuscador;
            set
            {
                _ArticulosBuscador = value;
                OnPropertyChanged();
            }
        }

        #region Constructor
        public paginaPrincipalViewModel(INavigation navPage)
        {
            nav = navPage;
            obtenerArticulos();
            refresarArticulos = new Command(obtenerArticulos);
            SearchCommand = new Command((para) => { obtenerPorId(para); });
            abrirVentana = new Command(abrirModal);
        }

        #endregion

        #region Metodos
        private async void obtenerArticulos()
        {
            IsBusy = true;
            var respuesta = await App.dbBase.obtenerArticulos();
            listaArticulos = new ObservableCollection<articuloModel>(respuesta);
            ArticulosBuscador = listaArticulos;
            IsBusy = false;
        }
        private async void obtenerPorId(object objArtiuculo)
        {
            if (objArtiuculo.ToString().Length > 0)
            {
                var vArticulo = (articuloModel)objArtiuculo;
                if (vArticulo.iIdArticulo != 0)
                {
                    var repuesta = await App.dbBase.obtenerArticulo(vArticulo.iIdArticulo);
                    listaArticulos = new ObservableCollection<articuloModel>();
                    listaArticulos.Add(repuesta);
                }
            }
            else
            {
                obtenerArticulos();
            }
        }
        private async void abrirModal()
        {
            await nav.PushModalAsync(new frmAgregarArticulos());
        }
        #endregion
    }
}
