using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab1ConsoleApp2020
{
    public class SupplierProduct
    {
        [Key, Column(Order = 0)]
        [ForeignKey("FK_Supplier")]
        public int SupplierID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("FK_Product")]
        public int ProductID { get; set; }
        public DateTime DateFirstSupplied { get; set; }

        public virtual Supplier FK_Supplier { get; set; }
        public virtual Product FK_Product { get; set; }

    }
}
