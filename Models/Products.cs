using System.ComponentModel.DataAnnotations;

namespace ProductCustomers.Models {
    public class BBProduct{
        public int productID {get; set;}

        [Display(Name ="Product Name")]
        [Required]
        public string pName {get; set;} = string.Empty;

        [Display(Name ="Product Price")]
        [Required]
        public double pPrice {get; set;}

        

    }
}