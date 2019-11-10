using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickType;
using SchoolHousing.Models;

namespace SchoolHousing.Pages.AffordableHouses
{
    public class CreateModel : PageModel
    {
        private readonly SchoolHousing.Models.SchoolHousingContext _context;

        public CreateModel(SchoolHousing.Models.SchoolHousingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AffordableHouse AffordableHouse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AffordableHouse.Add(AffordableHouse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}