using System.ComponentModel.DataAnnotations;

namespace ProductCustomers.Models {
    public class Customer{
        public int CustomerID {get; set;}

        [Display(Name ="First Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string firstName {get; set;} = string.Empty;

        [Display(Name ="Last Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string lastName {get; set;} = string.Empty;

        [Display(Name ="Email Address")]
        [EmailAddress]
        [Required]
        public string cEmail {get; set;} = string.Empty;

        public List<Order> Orders {get; set;} = default!; // Navigation property. Customer can have Many Orders

    }
    
    public class Order{
        public int ProductID {get; set;} // PK, FK 1 to Product Table
        public Product Product {get; set;} = default!; //Navigation Property

        public int CustomerID {get;set;} // PK, FK 2 to Product Table
        public Customer Customer {get; set;} = default!; //Navigation Property
        
        public int orderNum {get;set;} 
        public DateTime orderDate {get; set;}

        

    }
}