using GBCSporting2021_Mac_and_Cheese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Mac_and_Cheese.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId{ get; set;}
        [Required(ErrorMessage ="Please Select a Customer from the List")]
        public int CustomerId { get; set;}

        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please Select a Product from the List")]
        public int ProductId { get; set;}

        public Product Product { get; set; }

        [Required(ErrorMessage = "Please Enter a Title for the Incident")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter a Description for the Incident")]
        public string Description { get; set; }

        public int? TechnicianId { get; set;}

        public Technician Technician { get; set; }


        [Required(ErrorMessage = "Please Enter a Date for the Opening of Incident Report")]
        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }


    }
}
