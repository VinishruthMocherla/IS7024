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
    public JsonResult OnGet()
    {
            string schoolString = getJsonString("https://data.cityofchicago.org/resource/tj8h-mnuv.json");
            var schoolData = ElementarySchool.FromJson(schoolString);
          

            string houseString = getJsonString("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            var houseData = AffordableHouse.FromJson(houseString);
           

        return new JsonResult(schoolData);

    }

    private string getJsonString(String url)
    {
        using (var webClient = new WebClient())
        {
           return webClient.DownloadString(url);
        }
    }
}