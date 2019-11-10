using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuickType;
using SchoolHousing.Models;

namespace SchoolHousing.Pages.AffordableHouses
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolHousing.Models.SchoolHousingContext _context;

        public DetailsModel(SchoolHousing.Models.SchoolHousingContext context)
        {
            _context = context;
        }

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
    }
}
