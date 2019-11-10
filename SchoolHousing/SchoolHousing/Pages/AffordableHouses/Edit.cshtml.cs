using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickType;
using SchoolHousing.Models;

namespace SchoolHousing.Pages.AffordableHouses
{
    public class EditModel : PageModel
    {
        private readonly SchoolHousing.Models.SchoolHousingContext _context;

        public EditModel(SchoolHousing.Models.SchoolHousingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AffordableHouse AffordableHouse { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AffordableHouse = await _context.AffordableHouse.FirstOrDefaultAsync(m => m.SchoolId == id);

            if (AffordableHouse == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AffordableHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AffordableHouseExists(AffordableHouse.SchoolId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AffordableHouseExists(long id)
        {
            return _context.AffordableHouse.Any(e => e.SchoolId == id);
        }
    }
}
