using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita
{
    public class ProductoData
    {
        private string stringConnection;

        public ProductoData()
        {
            this.stringConnection = "Data Source=DESKTOP-JULFPC1;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public static Producto ObtenerProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM Producto WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            decimal precio = Convert.ToDecimal(reader["precio"]);
                            string descripcion = reader.GetString(3);

                            return new Producto(idObtenido, nombre, precio, descripcion);
                        }
                    }

                    throw new Exception("Id no encontrado");
                }
            }
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(ProductoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM Producto";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            decimal precio = Convert.ToDecimal(reader["precio"]);
                            string descripcion = reader.GetString(3);

                            productos.Add(new Producto(id, nombre, precio, descripcion));
                        }
                    }
                }
            }

            return productos;
        }

        public static bool CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "INSERT INTO Producto (Nombre, Precio, Descripcion) VALUES (@nombre, @precio, @descripcion)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ModificarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE Producto SET Nombre = @nombre, Precio = @precio, Descripcion = @descripcion WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "DELETE FROM Producto WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

