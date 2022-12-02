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
                    new Product {pName="Blue Nail Polish", pPrice=3.99m},
                    new Product {pName="Red Clay Mask", pPrice=7.99m},
                    new Product {pName="Foaming Fash Wash", pPrice=9.00m},
                    new Product {pName="Deep Moisturizing Face Cream", pPrice=10.00m},
                    new Product {pName="Lavender Body Lotion", pPrice=8.99m},
                    new Product {pName="Ultra Shine Hair Serum", pPrice=7.99m},
                    new Product {pName="Vanilla Body Lotion", pPrice=8.99m},
                    new Product {pName="Red Nail Polish", pPrice=3.99m},
                    new Product {pName="Coconut Body Lotion", pPrice=8.99m},
                    new Product {pName="Cleansing Face Wash", pPrice=9.00m},
                    new Product {pName="Anti-Wrinkle Face Cream", pPrice=12.00m},
                    new Product {pName="Purple Nail Polish", pPrice=3.99m},
                    new Product {pName="Volumizing Hair Mousse", pPrice=10.00m},
                    new Product {pName="Hydrating Face Cream", pPrice=12.00m},
                    new Product {pName="Stawberry Lipbalm", pPrice=10.00m},
                    new Product {pName="Rosewater Facial Toner", pPrice=6.99m},
                    new Product {pName="Pink Nail Polish", pPrice=3.99m},
                    new Product {pName="Shea Butter Body Lotion", pPrice=8.99m},
                    new Product {pName="Vanilla Showering Gel", pPrice=10.00m},
                    new Product {pName="Lavender Showing Gel", pPrice=10.00m},
                    new Product {pName="Hydrating Facial Toner", pPrice=6.99m},
                    new Product {pName="Acne Facial Cream", pPrice=7.00m},
                    new Product {pName="Make Removing Micellar Water", pPrice=7.00m},
                    new Product {pName="Water Sleeping Mask", pPrice=12.99m},
                    new Product {pName="Coco Body Oil", pPrice=5.00m},
                    new Product {pName="Ultra Hydrating Hand Cream", pPrice=4.00m},
                    new Product {pName="Intense Lip Treatment", pPrice=6.00m},
                    new Product {pName="Nail Cuticle Oil", pPrice=3.00m},
                    new Product {pName="Hair Repair Mask", pPrice=15.00m},
                    new Product {pName="10-In-1 Hair Mist", pPrice=11.00m},
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
                    new Order {orderNum = 1, productID = 8,orderDate = DateTime.Parse("11/20/2022")},
                    new Order {orderNum = 2, productID = 28,orderDate = DateTime.Parse("11/21/2022")},
                    new Order {orderNum = 3, productID = 21,orderDate = DateTime.Parse("11/22/2022")},
                    new Order {orderNum = 4, productID = 1,orderDate = DateTime.Parse("11/23/2022")},
                    new Order {orderNum = 5, productID = 6,orderDate = DateTime.Parse("11/24/2022")},
                    new Order {orderNum = 6, productID = 5,orderDate = DateTime.Parse("11/25/2022")},
                    new Order {orderNum = 7, productID = 31,orderDate = DateTime.Parse("11/26/2022")},
                    new Order {orderNum = 8, productID = 20,orderDate = DateTime.Parse("11/27/2022")},
                    new Order {orderNum = 9, productID = 14,orderDate = DateTime.Parse("11/28/2022")},
                    new Order {orderNum = 10, productID = 3,orderDate = DateTime.Parse("11/29/2022")},
                    new Order {orderNum = 11, productID = 12,orderDate = DateTime.Parse("11/30/2022")},
                    new Order {orderNum = 12, productID = 17,orderDate = DateTime.Parse("12/01/2022")},
                    new Order {orderNum = 13, productID = 21,orderDate = DateTime.Parse("12/02/2022")},
                    new Order {orderNum = 14, productID = 19,orderDate = DateTime.Parse("12/03/2022")},
                    new Order {orderNum = 15, productID = 7,orderDate = DateTime.Parse("12/04/2022")},
                    new Order {orderNum = 16, productID = 15,orderDate = DateTime.Parse("12/05/2022")},
                    new Order {orderNum = 17, productID = 22,orderDate = DateTime.Parse("12/06/2022")},
                    new Order {orderNum = 18, productID = 2,orderDate = DateTime.Parse("12/07/2022")},
                };
                context.AddRange(orders);

                context.SaveChanges();
            }
        }
    }
}