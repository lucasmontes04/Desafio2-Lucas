using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_Datos_Lucas_Montes_Pita
{
    public class ProductoVendidoData
    {
        private string stringConnection;

        public ProductoVendidoData()
        {
            this.stringConnection = "Server=.;Database=coderhouse;Trusted_Connection=True;";
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM ProductoVendido WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            decimal precioVenta = Convert.ToDecimal(reader["precioVenta"]);
                            DateTime fechaVenta = Convert.ToDateTime(reader["fechaVenta"]);

                            return new ProductoVendido(idObtenido, nombre, precioVenta, fechaVenta);
                        }
                    }

                    throw new Exception("Id no encontrado");
                }
            }
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM ProductoVendido";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            decimal precioVenta = Convert.ToDecimal(reader["precioVenta"]);
                            DateTime fechaVenta = Convert.ToDateTime(reader["fechaVenta"]);

                            productosVendidos.Add(new ProductoVendido(id, nombre, precioVenta, fechaVenta));
                        }
                    }
                }
            }

            return productosVendidos;
        }

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "INSERT INTO ProductoVendido (Nombre, PrecioVenta, FechaVenta) VALUES (@nombre, @precioVenta, @fechaVenta)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", productoVendido.Nombre);
                    command.Parameters.AddWithValue("@precioVenta", productoVendido.PrecioVenta);
                    command.Parameters.AddWithValue("@fechaVenta", productoVendido.FechaVenta);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ModificarProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE ProductoVendido SET Nombre = @nombre, PrecioVenta = @precioVenta, FechaVenta = @fechaVenta WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", productoVendido.Nombre);
                    command.Parameters.AddWithValue("@precioVenta", productoVendido.PrecioVenta);
                    command.Parameters.AddWithValue("@fechaVenta", productoVendido.FechaVenta);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.stringConnection))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "DELETE FROM ProductoVendido WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
