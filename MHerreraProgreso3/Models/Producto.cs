
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MHerreraProgreso3.Models
{
    class Producto
    {
        [PrimaryKey, AutoIncrement]

        public string Id { set; get; }
        public string Nombre { set; get; }
        public string Categoria { set; get; }
        public int Cantidad { set; get; }
        public decimal PrecioEstimado { set; get; }
    }
}
