using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        
        //Paging support
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} =10;

        // Sorting support
        [BindProperty(SupportsGet =true)]
        public string CurrentSort {get;set;}
        public async Task OnGetAsync()
        {   
           
            if (_context.Products != null)
            {
                 //Sorting query
                var query = _context.Products.Select(p => p);
                switch(CurrentSort){
                    case "first_asc":
                        query = query.OrderBy(p=> p.pName);
                        break;
                    case "first_desc":
                        query = query.OrderByDescending(p=>p.pName);
                        break;
                }

                Product = await query.Skip((PageNum -1)* PageSize).Take(PageSize).ToListAsync();

            }
        }
    }
}
