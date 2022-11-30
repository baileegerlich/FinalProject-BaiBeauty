using System.ComponentModel.DataAnnotations;

namespace ProductCustomers.Models {
    public class Product{
        public int productID {get; set;}

        [Display(Name ="Product Name")]
        [Required]
        public string pName {get; set;} = string.Empty;

        [Display(Name ="Product Price")]
        [Required]
        public double pPrice {get; set;}

        public List<Order> Orders {get; set;} = default!; //Navigation Property Product can be in many Orders

    }
}