using appInventario.Data;
using appInventario.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appInventario
{
    public partial class App : Application
    {
        private static dbArticulos _dbBase;
        public static dbArticulos dbBase 
        { 
            get
            {
                if (_dbBase == null)
                {
                    _dbBase = new dbArticulos(DependencyService.Get<iFileHelper>().obtenerRutaLocal("articulosdb.db3"));
                }
                return _dbBase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
