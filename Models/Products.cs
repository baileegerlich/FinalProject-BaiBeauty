using System;
using System.ComponentModel.DataAnnotations;

namespace ProductCustomers.Models {
    public class Product{
        public int ProductID {get; set;}

        [Display(Name ="Product Name")]
        [Required]
        public string pName {get; set;} = string.Empty;

        [Display(Name ="Product Price")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal pPrice {get; set;}

        public List<Order> Orders {get; set;} = default!; //Navigation Property Product can be in many Orders

    }
}