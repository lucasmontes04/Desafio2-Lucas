using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita.modelos
{
    public class usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string password;
        private string email;

        public usuario() { }
        public usuario(int id, string nombre, string apellido, string nombreUsuario, string password, string email)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}

