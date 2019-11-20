using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AffordableHouseResponse;
using ElementarySchoolResponse;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        
        {
            var schoolData = ElementarySchool.FromJson(JSONData("https://data.cityofchicago.org/resource/tj8h-mnuv.json"));
            ViewData["ElementarySchool"] = schoolData;
            


            var houseData = AffordableHouse.FromJson(JSONData("https://data.cityofchicago.org/resource/s6ha-ppgi.json"));
            ViewData["AffordableHouse"] = houseData;
           
        }

        
    }
    public string JSONData(string url)
    {
        String jsonString = "";
        using (var webClient = new WebClient())
        {
            jsonString = webClient.DownloadString(url);
        }
        return jsonString;
    }
    
}