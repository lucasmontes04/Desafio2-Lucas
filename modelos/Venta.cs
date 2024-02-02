using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita.modelos
{
    public class Venta
    {
        private int id;
        private string comentario;
        private int idUsuario;

        public Venta(int id, string comentario, int idUsuario)
        {
            this.id = id;
            this.comentario = comentario;
            this.idUsuario = idUsuario;
        }

        public int Id { get => this.id; set => this.id = value; }
        public string Comentario { get => this.comentario; set => this.comentario = value; }
        public int IdUsuario { get => this.idUsuario; set => this.idUsuario = value; }
    }
}
