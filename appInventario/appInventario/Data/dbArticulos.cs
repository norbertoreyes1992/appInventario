using appInventario.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace appInventario.Data
{
    public class dbArticulos
    {
        readonly SQLiteAsyncConnection dbConexion;

        public dbArticulos(string sRutaDb)
        {
            dbConexion = new SQLiteAsyncConnection(sRutaDb);
            dbConexion.CreateTableAsync<articuloModel>().Wait();
        }

        public async Task<List<articuloModel>> obtenerArticulos()
        {
            return await dbConexion.Table<articuloModel>().ToListAsync();
        }

        public Task<articuloModel> obtenerArticulo(int iId)
        {
            return dbConexion.Table<articuloModel>().Where(i => i.iIdArticulo == iId).FirstOrDefaultAsync();
        }

        public Task<int> guardarArticulo(articuloModel articulo)
        {
            if (articulo.iIdArticulo != 0)
            {
                return dbConexion.UpdateAsync(articulo);
            }
            else
            {
                return dbConexion.InsertAsync(articulo);
            }
        }

        public Task<int> eliminarArticulo(articuloModel articulo)
        {
            return dbConexion.DeleteAsync(articulo);
        }
    }
}
