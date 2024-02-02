using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita.modelos
{
   {
    public class Producto
    {
        private int id;
        private string descripcion;
        private double costo;
        private double precioVenta;
        private int idUsuario;

        public Producto(int id, string descripcion, double costo, double precioVenta, int idUsuario)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.idUsuario = idUsuario;
        }

        public int Id { get => this.id; set => this.id = value; }
        public string Descripcion { get => this.descripcion; set => this.descripcion = value; }
        public double Costo { get => this.costo; set => this.costo = value; }
        public double PrecioVenta { get => this.precioVenta; set => this.precioVenta = value; }
        public int IdUsuario { get => this.idUsuario; set => this.idUsuario = value; }
    }
}
}
