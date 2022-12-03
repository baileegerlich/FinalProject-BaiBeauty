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
        
        //Paging
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} =10;
        public async Task OnGetAsync()
        {
            Product = await _context.Products.Skip((PageNum -1)* PageSize).Take(PageSize).ToListAsync();
            // if (_context.Products != null)
            // {
            //     Product = await _context.Products.ToListAsync();
            // }
        }
    }
}
