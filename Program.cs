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

            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);

            //Console.WriteLine("Hello user, here are the current departments:");
            //Console.WriteLine("Please press enter...");
            //Console.ReadLine();
            var departments = repo.GetAllDepartments();

            foreach(var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }
        }
    }
}
