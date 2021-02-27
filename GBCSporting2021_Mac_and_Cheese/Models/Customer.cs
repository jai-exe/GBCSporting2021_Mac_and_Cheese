using GBCSporting2021_Mac_and_Cheese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Mac_and_Cheese.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [Required(ErrorMessage = "Please Enter the First Name")]
        public string CustFName { get; set; }

        [Required(ErrorMessage = "Please Enter the Last Name")]
        public string CustLName { get; set; }

        [Required(ErrorMessage = "Please Enter the Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter the City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter the State")]
        public string State { get; set; }

        [Range(1, 4, ErrorMessage = "Please Select a Country from the Dropdown Menu")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public string PostalCode { get; set; }
        public string CustEmail { get; set; }

        public string CustPhone { get; set; }



    }
}
