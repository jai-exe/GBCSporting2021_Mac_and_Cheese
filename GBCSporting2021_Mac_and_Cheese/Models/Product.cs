using GBCSporting2021_Mac_and_Cheese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Mac_and_Cheese.Models
{
    public class Product
    {
        [Key] 
        public int ProductId { get; set; }
        public string Code { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public DateTime DateReleased { get; set; }

    }
}
