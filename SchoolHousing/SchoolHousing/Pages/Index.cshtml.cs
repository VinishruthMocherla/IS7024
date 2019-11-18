using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using AffordableHousesResponse;
using ElementarySchoolResponse;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        using (var webClient = new WebClient())
        {
            string schoolString = webClient.DownloadString("https://data.cityofchicago.org/Education/Chicago-Public-Schools-Elementary-School-Progress-/tj8h-mnuv/data");
            var schoolData = ElementarySchool.FromJson(schoolString);
            ViewData["ElementarySchool"] = schoolData;
        }
        using (var webClient = new WebClient())
        {
            string houseString = webClient.DownloadString("https://data.cityofchicago.org/Community-Economic-Development/Affordable-Rental-Housing-Developments/s6ha-ppgi/data");
            var houseData = AffordableHouse.FromJson(houseString);
            ViewData["AffordableHouse"] = houseData;
        }
    }
}