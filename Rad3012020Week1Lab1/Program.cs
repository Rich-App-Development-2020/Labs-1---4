using ActivityTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad3012020Week1Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity.Track("Designing Classes Model");
            Activity.Track("Starting Queries");
            Console.WriteLine();

            //finish listing the objects

            ProductModel model = new ProductModel();

            //listing all the categories
            Console.WriteLine("CATEGORIES");
            Console.WriteLine("------------");
            foreach (var item in model.categories)
            {
                Console.WriteLine("{0}", item.description);
            }
            Console.WriteLine("------------");
            Console.WriteLine();

            //listing all the products
            Console.WriteLine("PRODUCTS");
            Console.WriteLine("------------");
            foreach (var item in model.products)
            {
                Console.WriteLine(item.description);
            }
            Console.WriteLine("------------");
            Console.WriteLine();


            //listing all the products with a quantity of less than 100
            Console.WriteLine("PRODUCTS WITH QUANTITY LESS THAN 100");
            Console.WriteLine("------------");
            var under100 = model.products
                                        .Where(p => p.QuantityInStock <= 100)
                                        .OrderByDescending(p => p.QuantityInStock);
            foreach (var item in under100)
            {
                Console.WriteLine(item.description);
            }
            Console.WriteLine("------------");
            Console.WriteLine();

            //listing all the products together with their total value
            Console.WriteLine("ALL THE PRODUCTS TOGTHER WITH THEIR TOTAL VALUE");
            Console.WriteLine("------------");
            foreach (var item in model.products)
            {
                float totalValue = item.QuantityInStock * item.UnitPrice;
                Console.WriteLine(item.description + "\t\t {0:C}", totalValue);
            }
            Console.WriteLine("------------");
            Console.WriteLine();

            //List all the Products in the Hardware Category
            Console.WriteLine("ALL THE PRODUCTS IN THE HARDWARE CATEGORY");
            var hardware = model.products.Where(s => s.CategoryID == 1);
            foreach (var item in hardware)
            {
                Console.WriteLine(item.description);
            }

            //List all the suppliers, their Parts and order it by supplier name
            //var suppliers = model.suppliers;

            //var idk = (from s in model.supplierProducts
            //           join p in model.products on s.ProductID equals p.ProductID
            //           where p.ProductID == s.ProductID
            //           select( s.)

        }
    }
}
