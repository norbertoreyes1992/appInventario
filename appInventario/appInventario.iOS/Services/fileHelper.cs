using appInventario.iOS.Services;
using appInventario.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(fileHelper))]
namespace appInventario.iOS.Services
{
    public class fileHelper : iFileHelper
    {
        public string obtenerRutaLocal(string sArchivo)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "DataBases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, sArchivo);
        }
    }
}