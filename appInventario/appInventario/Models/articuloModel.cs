using SQLite;

namespace appInventario.Models
{
    public class articuloModel
    {
        [PrimaryKey, AutoIncrement]
        public int iIdArticulo { get; set; }
        public string sSkuArticulo { get; set; }
        public string sNombreArticulo { get; set; }
        public string sDescripcionArt { get; set; }
        public double dPrecioArticulo { get; set; }
        public byte[] imagen { get; set; }
        public bool bEstatus { get; set; }
    }
}
