using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DotNetCoreWebApp.Controllers
{
    public class SQLQueries
    {
        static string ConnectionString = "Data Source=pearltestdb.database.windows.net;" + "Initial Catalog=CheckItOutdb;" + "User id=ntahiri;" + "Password=Faisal123;";

        //GenericGroceryItems holds common grocery items one may search for, this function gets these items
        public static List<string> GetGenericProductNames()
        {
            List<string> genericProductNames = new List<string>();

            SqlConnection sqlConnection1 =
            new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            sqlConnection1.Open();
            string query = "SELECT ProductCategory FROM GenericGroceryItems";
            using (SqlCommand command = new SqlCommand(query, sqlConnection1))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genericProductNames.Add(reader.GetString(0));
                    }
                }
            }
            return genericProductNames;
        }

        public static List<Product> GetProductListings(string productCategory)
        {
            //parameterized query to protect against injection attack
            string query = "SELECT * FROM dbo.TestProductTable WHERE ProductCategory = @ProductCategory";

            //establish connections
            SqlConnection sqlConnection1 =
            new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(query, sqlConnection1);

            //Add parameter value
            cmd.Parameters.Add("@ProductCategory", SqlDbType.VarChar, 100);
            cmd.Parameters["@ProductCategory"].Value = productCategory;

            cmd.CommandType = CommandType.Text;
            sqlConnection1.Open();

            //List of Product object
            List<Product> products = new List<Product>();

            using (cmd)
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //create new product (empty)
                        Product prdct = new Product();

                        //populate contents with this row's values
                        prdct.ProductName = reader.GetValue(0).ToString();
                        prdct.ProductCategory = reader.GetValue(1).ToString();
                        prdct.ProductPrice = double.Parse((reader.GetValue(2).ToString()));
                        prdct.Source = reader.GetValue(3).ToString();
                        prdct.TimeGenerated = DateTime.Parse(reader.GetValue(4).ToString());

                        //add populated product to list
                        products.Add(prdct);
                    }
                }
            }
            //Return list of products
            return products;
        }
    }
}
