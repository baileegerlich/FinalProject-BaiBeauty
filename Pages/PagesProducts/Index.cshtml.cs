using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCustomers.Models;

namespace FinalProject_BaiBeauty.PagesProducts
{
    public class IndexModel : PageModel
    {
        private readonly ProductCustomers.Models.pcDbContext _context;

        public IndexModel(ProductCustomers.Models.pcDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        //Search Items
        [BindProperty(SupportsGet = true)]
        public string? SearchString {get;set;}
    

    
        [BindProperty(SupportsGet = true)]
        public string ProductName { get; set; } = default!;
        
        //Paging support
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} =10;

        // Sorting support
        [BindProperty(SupportsGet =true)]
        public string CurrentSort {get;set;} = string.Empty;
        // Second sorting technique with a SelectList
        public SelectList? SortList{get; set;}
        public async Task OnGetAsync()
        {   
           
            if (_context.Products != null)
            {   
                //Search products using Syntax method and Linq
                var products = from p in _context.Products
                    select p;
                if(SearchString != null){
                    products = products.Where(p=>p.pName.Contains(SearchString));
                }
                Product = await products.ToListAsync();
                var query = products.Select(p=>p);

                //Sort Items
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem {Text ="Ascending", Value ="first_asc"},
                    new SelectListItem {Text = "Descending", Value="sec_"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);
                
                
                //Sorting for each Category
                switch(CurrentSort){
                    case "first_asc":
                        query = query.OrderBy(p=> p.pName);
                        break;
                    case "first_desc":
                        query = query.OrderByDescending(p=>p.pName);
                        break;
                    case "sec_asc":
                        query = query.OrderBy(p=>p.pPrice);
                        break;
                    case "sec_desc":
                        query = query.OrderByDescending(p=>p.pPrice);
                        break;
                }
                Product = await _context.Products.Include(p=> p.Orders).ThenInclude(c=> c.Customer).ToListAsync();
                Product = await query.Skip((PageNum -1)* PageSize).Take(PageSize).ToListAsync();

            }
            
        }
    }
}
