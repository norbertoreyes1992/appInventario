using appInventario.Droid.Services;
using appInventario.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(fileHelper))]
namespace appInventario.Droid.Services
{
    public class fileHelper : iFileHelper
    {
        public string obtenerRutaLocal(string sArchivo)
        {
            string sRuta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(sRuta, sArchivo);
        }
    }
}