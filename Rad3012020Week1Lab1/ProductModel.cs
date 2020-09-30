using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad3012020Week1Lab1
{
    public class ProductModel
    {
        public List<Product> products = new List<Product>
        {
            new Product {                ProductID = 1, description = "9\" Nails", QuantityInStock = 200, UnitPrice = 0.10f, CategoryID = 1},
            new Product {                ProductID = 2, description = "9\" Bolts", QuantityInStock = 120, UnitPrice = 0.20f, CategoryID = 1},
            new Product {                ProductID = 3, description = "Chimney Hoover", QuantityInStock = 10, UnitPrice = 100.50f,CategoryID = 2},
            new Product {                ProductID = 4, description = "Washing Machine", QuantityInStock = 7, UnitPrice = 399.99f , CategoryID = 2},
    };
}
    
    public class Product
    {
        public int ProductID; // Key Field
        public string description { get; set; }
        public int QuantityInStock { get; set; }
        public float UnitPrice { get; set; }
        public int CategoryID { get; set; }

    }
    public class Category
    {
        public int id { get; set; }
        public string description { get; set; }

    }
    public class SupplierProduct
    {
        public int SupplierID { get; set; }

        public int ProductID { get; set; }

        public DateTime DateFirstSupplied { get; set; }

    }
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

    }
}
