using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductCustomers.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject_BaiBeauty.PagesProducts
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly ProductCustomers.Models.pcDbContext _context;

        public DetailsModel(ProductCustomers.Models.pcDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Product Product { get; set; } = default!; 
        // Delete Customer
        [BindProperty]
        public int CustomerIdToDelete {get;set;}
        
        // Add Customer
        [BindProperty]
        [Display(Name ="Customer")]
        public int CustomerIdToAdd {get;set;}
        //List Customer/Dropdown
        public List<Customer>AllCustomers {get;set;} = default!;
        [BindProperty]
        [Required]
        public SelectList CustomerDropDown{get;set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        { 
             if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(s => s.Orders!).ThenInclude(sc => sc.Customer).FirstOrDefaultAsync(m => m.ProductID == id);
            AllCustomers = await _context.Customers.ToListAsync();
            CustomerDropDown = new SelectList(AllCustomers, "CustomerID", "firstName","lastName");
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
        // OnPost for Delete Customer
         public async Task<IActionResult> OnPostDeleteCustomerAsync(int? id)
        {
            _logger.LogWarning($"OnPost: ProductID {id}, DROP Customer {CustomerIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(s => s.Orders!).ThenInclude(sc => sc.Customer).FirstOrDefaultAsync(m => m.ProductID == id);
            
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }

            Order customerToDrop = _context.Order.Find(CustomerIdToDelete, id.Value)!;

            if (customerToDrop != null)
            {
                _context.Remove(customerToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("No Customer to Drop");
            }

            return RedirectToPage(new {id = id});
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: CustomerID {id}, ADD Customer {CustomerIdToAdd} {}");
            if (CustomerIdToAdd == 0)
            {
                ModelState.AddModelError("CustomerIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(s => s.Orders!).ThenInclude(sc => sc.Customer).FirstOrDefaultAsync(m => m.ProductID == id);            
            AllCustomers = await _context.Customers.ToListAsync();
            CustomerDropDown = new SelectList(AllCustomers, "CustomerID", "firstName","lastName");

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }

            if (!_context.Order.Any(sc => sc.CustomerID == CustomerIdToAdd && sc.ProductID == id.Value))
            {
                Order customerToAdd = new Order { ProductID = id.Value, CustomerID = CustomerIdToAdd};
                _context.Add(customerToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Customer is already in this order.");
            }

            return RedirectToPage(new {id = id});
        }
        
    }
}

