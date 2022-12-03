using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductCustomers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FinalProject_BaiBeauty.Pages;

public class BaiBeautyModel : PageModel
{
    //Dependency Injection PT.2
    private readonly pcDbContext _context; // Replaces the "db" variable from before

    private readonly ILogger<BaiBeautyModel> _logger;

    //Gather Data
    public List<Product> Products {get; set;} = default!;

    public BaiBeautyModel (pcDbContext context, ILogger<BaiBeautyModel> logger)
    {
        _context = context; // Read in DbContext here
        _logger = logger;
    }

    public void OnGet()
    {
        Products = _context.Products.ToList();
    }
}
