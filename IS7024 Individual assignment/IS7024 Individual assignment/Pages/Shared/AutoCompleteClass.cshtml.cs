using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IS7024_Individual_assignment.Pages.Shared
{
    public class AutocompleteModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> classNames = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["term"];

            AddClass("IT Management");
            AddClass("IT Security");
            AddClass("Web development using XML");
            AddClass("Web development with .NET");
            AddClass("IS Management");
            AddClass("IS Security");

            return new JsonResult(classNames);
        }

        private void AddClass(string className)
        {
            string lowername = className.ToLower();
            string lowerterm = Term.ToLower();
            if (lowername.Contains(lowerterm))
            {
                classNames.Add(className);
            }
        }
    }
}