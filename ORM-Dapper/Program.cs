using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);

           var repo = new DapperProductRepository(connection);

            repo.CreateProduct("newStuff", 20, 1);

            var productToUpdate = repo.GetProduct(73); 

           var products = repo.GetAllProducts();

            productToUpdate.Name = "Nickelback: Silver Side Up";
            productToUpdate.Price = 12.99;
            productToUpdate.CategoryID = 7;
            productToUpdate.OnSale = 0;
            productToUpdate.StockLevel = "1070";

            repo.UpdateProduct(productToUpdate);

            repo.DeleteProduct(944);

           


            foreach ( var prod in products )
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }
        }
    }
}
