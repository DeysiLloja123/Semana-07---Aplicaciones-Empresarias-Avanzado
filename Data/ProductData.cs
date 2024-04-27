using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductData
    {
        private string connectionString = "Data Source=LAB1504-27\\SQLEXPRESS;Initial Catalog=Factura;User Id=UserTecsup;Password=123";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_listarProducto", connection)) // Reemplaza "GetProducts" con el nombre de tu procedimiento almacenado
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.product_id = Convert.ToInt32(reader["product_id"]);
                            product.name = reader["name"].ToString();
                            product.price = Convert.ToDouble(reader["price"]);
                            product.stock = Convert.ToInt32(reader["stock"]);
                            product.active = Convert.ToInt32(reader["active"]);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        public List<Product> GetByName(string name)
{
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_listarProductoNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.product_id = Convert.ToInt32(reader["product_id"]);
                            product.name = reader["name"].ToString();
                            product.price = Convert.ToDouble(reader["price"]);
                            product.stock = Convert.ToInt32(reader["stock"]);
                            product.active = Convert.ToInt32(reader["active"]);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void Insert()
        {
        }
        public void Update()
        {
        }
        public void Delete()
        {
        }
    }
}
