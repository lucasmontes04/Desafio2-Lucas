using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita.modelos
{
    public class ProductoVendido
    {
        private int id;
        private int idProducto;
        private int stock;
        private int idVenta;

        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            this.id = id;
            this.idProducto = idProducto;
            this.stock = stock;
            this.idVenta = idVenta;
        }

        public int Id { get => this.id; set => this.id = value; }
        public int IdProducto { get => this.idProducto; set => this.idProducto = value; }
        public int Stock { get => this.stock; set => this.stock = value; }
        public int IdVenta { get => this.idVenta; set => this.idVenta = value; }
    }
}
