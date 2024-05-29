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

            var productToUpdate = repo.GetProduct(974); 

           var products = repo.GetAllProducts();

            productToUpdate.Name = "UPDATED!!";
            productToUpdate.Price = 12.99;
            productToUpdate.CategoryID = 1;
            productToUpdate.OnSale = false;
            productToUpdate.StockLevel = 1000;

            productRepository.UpdateProduct(productToUpdate);

            productRepository.Deleteproduct(974);

            var products = productRepository.GetAllProducts();


            foreach ( var prod in products )
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }
        }
    }
}
