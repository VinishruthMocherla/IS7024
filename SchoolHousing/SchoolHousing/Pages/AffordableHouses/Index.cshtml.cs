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
    public class IndexModel : PageModel
    {
        private readonly SchoolHousing.Models.SchoolHousingContext _context;

        public IndexModel(SchoolHousing.Models.SchoolHousingContext context)
        {
            _context = context;
        }

        public IList<AffordableHouse> AffordableHouse { get;set; }

        public async Task OnGetAsync()
        {
            AffordableHouse = await _context.AffordableHouse.ToListAsync();
        }
    }
}
