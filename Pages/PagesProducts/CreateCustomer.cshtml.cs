
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProductCustomers.Models;


namespace FinalProject_BaiBeauty.Pages;

public class CreateCustomerModel : PageModel
{   
    [BindProperty]
    [Display(Name = "First Name")]
    [StringLength(60, MinimumLength =3)] //Data validation
    [Required]
    public string firstName {get; set;} = string.Empty;

    [BindProperty]
    [Display(Name = "Last Name")]
    [StringLength(60, MinimumLength =3)] //Data validation
    [Required]
    public string lastName {get; set;} = string.Empty;

    [BindProperty]
    [Display(Name = "Email Address")]
    [EmailAddress] //Data validation
    [Required]
    public string cEmail {get; set;} = string.Empty;

    [BindProperty]
    public Customer Customer{get;set;} = default!;

    private readonly pcDbContext _context;
    private readonly ILogger<CreateCustomerModel> _logger;

    public CreateCustomerModel(pcDbContext context,ILogger<CreateCustomerModel> logger)
    {   
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost(){
        // if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

            _context.Customers.Add(Customer);
            _context.SaveChanges();

            return RedirectToPage("./Index");
    }
}