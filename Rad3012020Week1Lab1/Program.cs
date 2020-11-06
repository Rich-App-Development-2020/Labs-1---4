/* #############################
 * 
 * Author: Johnathon Mc Grory
 * Date : 4/10/2020
 * Description : C# Code for Week One Lab One 2020 Third year Semester One 
 * 
 * ############################# `*/

using ActivityTracker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad3012020Week1Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //changes the currency cymbol from £ to "EUR";
            CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.LCID);
            info.NumberFormat.CurrencySymbol = "EUR ";
            System.Threading.Thread.CurrentThread.CurrentCulture = info;

            //Track activities
            Activity.Track("Designing Classes Model");
            Activity.Track("Starting Queries");
            Console.WriteLine();

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
                Console.WriteLine(item.description + "\t\t{0:C}", totalValue);
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

            //IMPORTANT: Struggled with this question and currently awaiting solution to see how it is done
            var suppliersAndParts = (from Suppliers in model.suppliers
                                     join SupplierProducts in model.supplierProducts
                                     on Suppliers.SupplierID equals SupplierProducts.SupplierID
                                     join Products in model.products
                                     on SupplierProducts.ProductID equals Products.ProductID
                                     orderby Suppliers.SupplierName
                                     select new
                                     {
                                         Suppliers.SupplierName,
                                         Products.description,
                                     }); ;

            Console.WriteLine("Query 6 List all the suppliers and their Parts ordered by supplier name");
            foreach (var item in suppliersAndParts)
            {
                Console.WriteLine(item);
            }
        }
    }
}