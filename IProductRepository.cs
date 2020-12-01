using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string newProductName, double newPrice, int newCategoryID);
        void UpdateProduct(int productID, string updateName);
    }
}
