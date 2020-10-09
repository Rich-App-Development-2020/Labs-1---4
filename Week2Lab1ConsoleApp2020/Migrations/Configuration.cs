namespace Week2Lab1ConsoleApp2020.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week2Lab1ConsoleApp2020.DbBusinessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week2Lab1ConsoleApp2020.DbBusinessContext context)
        {
            #region addingCategories
            context.Categories.AddOrUpdate(new Category[]
                {
                    new Category { CategoryID = 1, Description = "Hardware" },
                    new Category { CategoryID = 2, Description = "Electrical Appliances" },
                });
            context.SaveChanges();
            #endregion addingCategories

            #region addingProducts
            DateTime baseDate = DateTime.Parse("02/12/2018");
            Random r = new Random();
            context.Products.AddOrUpdate(new Product[]
                {
                    new Product { ID = 1, Description = " 9 inch nails", DateFirstissued = baseDate.AddDays(r.Next(5,15)), UnitPrice = 0.10f, QuantityInStock = 200, CategoryID = 1},
                    new Product { ID = 2, Description = " 9 inch bolts", DateFirstissued = baseDate.AddDays(r.Next(5,15)), UnitPrice = 0.20f, QuantityInStock = 120, CategoryID = 1},
                    new Product { ID = 3, Description = "Chimney Hoover", DateFirstissued = baseDate.AddDays(r.Next(5,15)), UnitPrice = 100.5f, QuantityInStock = 10, CategoryID = 2},
                    new Product { ID = 4, Description = "Washing Machine", DateFirstissued = baseDate.AddDays(r.Next(5,15)), UnitPrice = 399.99f, QuantityInStock = 7, CategoryID = 2},

                });
            context.SaveChanges();
            #endregion addingProducts

            #region addingSuppliers
            context.Suppliers.AddOrUpdate(new Supplier[]
               {
                    new Supplier { SupplierID = 1, SupplierName = "Joe Bloggs", SupplierAddressLine1 = "The Coop", SupplierAddressLine2 = "Coopersville" },
                    new Supplier { SupplierID = 2, SupplierName = "Mary Quant", SupplierAddressLine1 = "Priory Road", SupplierAddressLine2 = "" }
               });
            context.SaveChanges();
            #endregion addingSuppliers

            #region addingSupplierProducts
            context.SupplierProducts.AddOrUpdate(new SupplierProduct[]
               {
                    new SupplierProduct { SupplierID = 1, ProductID = 1, DateFirstSupplied = baseDate.AddDays(r.Next(5,15))},
                    new SupplierProduct { SupplierID = 1, ProductID = 2, DateFirstSupplied = baseDate.AddDays(r.Next(5,15))},
                    new SupplierProduct { SupplierID = 2, ProductID = 3, DateFirstSupplied = baseDate.AddDays(r.Next(5,15))},
                    new SupplierProduct { SupplierID = 2, ProductID = 4, DateFirstSupplied = baseDate.AddDays(r.Next(5,15))},
               });
            context.SaveChanges();
            #endregion addingSupplierProducts
        }
    }
}
