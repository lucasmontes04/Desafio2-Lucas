using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita
{
    public class UsuarioData
    {
        private string stringConnection;

        public UsuarioData()
        {
            this.stringConnection = "Server=.;Database=coderhouse;Trusted_Connection=True;";
        }



        public static Usuario ObtenerUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
               string query = "SELECT * FROM Usuario WHERE id = 1";
                using (SqlCommand command = new SqlCommand(query, connection))

                    connection.Open(); 
                {
                    connection.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = connection.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            string apellido = reader.GetString(2);
                            string nombreUsuario = reader.GetString(3);
                            string password = reader.GetString(4);
                            string email = reader.GetString(5);

                            return new Usuario(idObtenido, nombre, apellido, nombreUsuario, password, email);
                        }
                    }

                    throw new Exception("Id no encontrado");
                }
            }
        }

        
    }
}
