using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            //Console.WriteLine(connString);
            #endregion

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
            //exercise 2 portion:
            var repo2 = new DapperProductRepository(conn);
            //bonus 1 update product
            var repo3 = new DapperProductRepository(conn);
            //bonus 2 extra delete products
            var repo4 = new DapperProductRepository(conn);


            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);

            Console.WriteLine("Type a new Product name");
            var newProduct = Console.ReadLine();
            Console.WriteLine("What is the price?");
            var newPrice = Console.ReadLine();
            Console.WriteLine("Give it a category ID");
            var newCategoryID = Console.ReadLine();
            repo2.CreateProduct(newProduct, double.Parse(newPrice), int.Parse(newCategoryID));


            Console.WriteLine("What is the product ID of the item you want to change the name of?");
            var productID = Console.ReadLine();
            Console.WriteLine("What do you want to change the product name to?");
            var updateName = Console.ReadLine();
            repo3.UpdateProduct(int.Parse(productID), updateName);


            Console.WriteLine("What is the product ID you would like to delete?");
            var deleteProduct = Console.ReadLine();
            repo4.DeleteProduct(int.Parse(deleteProduct));

            
            var departments = repo.GetAllDepartments();

            foreach(var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }


            var products = repo2.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
            }


            var products2 = repo3.GetAllProducts();

            foreach (var product in products2)
            {
                Console.WriteLine(product.Name);
            }


            var products3 = repo4.GetAllProducts();

            foreach (var product in products3)
            {
                Console.WriteLine(product.Name);
            }
        }   
    }
}
