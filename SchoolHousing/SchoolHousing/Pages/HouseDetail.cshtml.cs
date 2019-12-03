using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Housing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolHousing.Pages
{
    public class HouseDetailModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string houseDetailString = webClient.DownloadString("https://neighborhoodgroceryappxmlproject.azurewebsites.net/api/Neighbor/GetHousingData/Washington%20Park");
                var houseDetail = HousingModel.FromJson(houseDetailString);
                ViewData["HousingDetail"] = houseDetail;

                
            }
        }
    }
}