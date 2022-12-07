using Microsoft.EntityFrameworkCore;

namespace ProductCustomers.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new pcDbContext(serviceProvider.GetRequiredService<DbContextOptions<pcDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                //Seed Products. 31 Total products
                List<Product> products = new List<Product> {
                    new Product {pName="Blue Nail Polish", pPrice=3.99},
                    new Product {pName="Red Clay Mask", pPrice=7.99},
                    new Product {pName="Foaming Fash Wash", pPrice=9.00},
                    new Product {pName="Deep Moisturizing Face Cream", pPrice=10.00},
                    new Product {pName="Lavender Body Lotion", pPrice=8.99},
                    new Product {pName="Ultra Shine Hair Serum", pPrice=7.99},
                    new Product {pName="Vanilla Body Lotion", pPrice=8.99},
                    new Product {pName="Red Nail Polish", pPrice=3.99},
                    new Product {pName="Coconut Body Lotion", pPrice=8.99},
                    new Product {pName="Cleansing Face Wash", pPrice=9.00},
                    new Product {pName="Anti-Wrinkle Face Cream", pPrice=12.00},
                    new Product {pName="Purple Nail Polish", pPrice=3.99},
                    new Product {pName="Volumizing Hair Mousse", pPrice=10.00},
                    new Product {pName="Hydrating Face Cream", pPrice=12.00},
                    new Product {pName="Stawberry Lipbalm", pPrice=10.00},
                    new Product {pName="Rosewater Facial Toner", pPrice=6.99},
                    new Product {pName="Pink Nail Polish", pPrice=3.99},
                    new Product {pName="Shea Butter Body Lotion", pPrice=8.99},
                    new Product {pName="Vanilla Showering Gel", pPrice=10.00},
                    new Product {pName="Lavender Showing Gel", pPrice=10.00},
                    new Product {pName="Hydrating Facial Toner", pPrice=6.99},
                    new Product {pName="Acne Facial Cream", pPrice=7.00},
                    new Product {pName="Make Removing Micellar Water", pPrice=7.00},
                    new Product {pName="Water Sleeping Mask", pPrice=12.99},
                    new Product {pName="Coco Body Oil", pPrice=5.00},
                    new Product {pName="Ultra Hydrating Hand Cream", pPrice=4.00},
                    new Product {pName="Intense Lip Treatment", pPrice=6.00},
                    new Product {pName="Nail Cuticle Oil", pPrice=3.00},
                    new Product {pName="Hair Repair Mask", pPrice=15.00},
                    new Product {pName="10-In-1 Hair Mist", pPrice=11.00},
                };
                context.AddRange(products);
                //Seed Customers. 7 Total Customers
                List<Customer> customers = new List<Customer> {
                    new Customer {firstName ="Becca", lastName = "Orthengren", cEmail ="beccaorthengran@gmail.com"},
                    new Customer {firstName ="Bailee", lastName = "Gerlich", cEmail ="baileegerlich@gmail.com"},
                    new Customer {firstName ="Marsha", lastName = "Eskew", cEmail ="marshaeskew@gmail.com"},
                    new Customer {firstName ="Shirley", lastName = "Blank", cEmail ="shirleyblank@gmail.com"},
                    new Customer {firstName ="Tracey", lastName = "morris", cEmail ="traceymorris@gmail.com"},
                    new Customer {firstName ="Sara", lastName = "Stater", cEmail ="sarahstater@gmail.com"},
                    new Customer {firstName ="Becky", lastName = "Davis", cEmail ="beckdavis@gmail.com"},
                };
                context.AddRange(customers);

                List<Order> orders = new List<Order> {
                    new Order {CustomerID =1,orderNum = 1, ProductID = 8,orderDate = DateTime.Parse("11/20/2022")},
                    new Order {CustomerID =2,orderNum = 2, ProductID = 28,orderDate = DateTime.Parse("11/21/2022")},
                    new Order {CustomerID =3,orderNum = 3, ProductID = 21,orderDate = DateTime.Parse("11/22/2022")},
                    new Order {CustomerID =4,orderNum = 4, ProductID = 1,orderDate = DateTime.Parse("11/23/2022")},
                    new Order {CustomerID =5,orderNum = 5, ProductID = 6,orderDate = DateTime.Parse("11/24/2022")},
                    new Order {CustomerID =6,orderNum = 6, ProductID = 5,orderDate = DateTime.Parse("11/25/2022")},
                    new Order {CustomerID =7,orderNum = 7, ProductID = 30,orderDate = DateTime.Parse("11/26/2022")},

                };
                context.SaveChanges();
                
                context.AddRange(orders); 
            }
        }
    }
}