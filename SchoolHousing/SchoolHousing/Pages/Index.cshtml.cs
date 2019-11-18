using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using AffordableHouseResponse;
using ElementarySchoolResponse;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        using (var webClient = new WebClient())
        {
            string schoolString = webClient.DownloadString("https://data.cityofchicago.org/resource/tj8h-mnuv.json");
            var schoolData = ElementarySchool.FromJson(schoolString);
            ViewData["ElementarySchool"] = schoolData;

            string houseString = webClient.DownloadString("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            var houseData = AffordableHouse.FromJson(houseString);
            ViewData["AffordableHouse"] = houseData;
        }
    }
}