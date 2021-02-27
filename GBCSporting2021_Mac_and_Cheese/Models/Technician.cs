using GBCSporting2021_Mac_and_Cheese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Mac_and_Cheese.Models
{
    public class Technician
    {
        [Key]
        public int TechId { get; set; }

        public string TechName { get; set; }

        public string TechEmail { get; set; }

        public string TechPhone { get; set; }


    }
}
