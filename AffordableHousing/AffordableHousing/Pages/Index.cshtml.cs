using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace AffordableHousing.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using(var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("MyFinalURL");
                var affordableHouse = AffordableHouse.FromJson(jsonString);
                ViewData["AffordableHouse"] = affordableHouse;
            }
        }
    }
}
