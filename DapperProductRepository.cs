using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }
        public void CreateProduct(string newProductName, double newPrice, int newCategoryID)
        {
            //_connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName);",
            //    new { productName = newProductName });

            //_connection.Execute("INSERT INTO PRODUCTS (Price) VALUES (@price);",
            //    new { price = newPrice });

            //_connection.Execute("INSERT INTO PRODUCTS (CategoryID) VALUES (@categoryID);",
            //    new { categoryID = newCategoryID });

            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @price, @categoryID);",
                new { productName = newProductName, price = newPrice, categoryID = newCategoryID });
        }
        public void UpdateProduct(int productID, string updateName) //not sure what to put in the paranthesis yet
        {

        }
        public void DeleteProduct() //not sure what to put in the paranthesis yet
        {

        }
    }
}
