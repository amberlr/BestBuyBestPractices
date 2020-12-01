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
        }   
    }
}
