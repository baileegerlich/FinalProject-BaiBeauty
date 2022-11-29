using System.ComponentModel.DataAnnotations;

namespace ProductCustomers.Models {
    public class Customer{
        public int customerID {get; set;}

        [Display(Name ="First Name")]
        [Required]
        public string firstName {get; set;} = string.Empty;

        [Display(Name ="Last Name")]
        [Required]
        public string lastName {get; set;} = string.Empty;

        [Display(Name ="Email Address")]
        [EmailAddress]
        [Required]
        public string cEmail {get; set;} = string.Empty;

    }
}