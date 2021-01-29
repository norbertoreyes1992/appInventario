using appInventario.Services;
using appInventario.UWP.Services;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(fileHelper))]
namespace appInventario.UWP.Services
{
    public class fileHelper : iFileHelper
    {
        public string obtenerRutaLocal(string sArchivo)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, sArchivo);
        }
    }
}
