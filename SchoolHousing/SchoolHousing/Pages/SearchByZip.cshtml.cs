using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AffordableHouseResponse;
using ElementarySchoolResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SchoolHousing.Pages
{
    public class SearchByZipModel : PageModel
    {
        private readonly ILogger<SearchByZipModel> _logger;
        public SearchByZipModel(ILogger<SearchByZipModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

            SearchCompleted = false;

        }
        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        List<AffordableHouse> houseNearSchool = new List<AffordableHouse>();
        ElementarySchool newSchool = new ElementarySchool();

        public void OnPost()
        {
            string schoolJson = GetData("https://data.cityofchicago.org/resource/tj8h-mnuv.json");
            ElementarySchool[] allSchool = ElementarySchool.FromJson(schoolJson);
            string HouseJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            AffordableHouse[] allHouse = AffordableHouse.FromJson(HouseJson);
            foreach (AffordableHouse house in allHouse)
            {
                if (house.ZipCode != null)
                {
                    
                    
                        houseNearSchool.Add(house);
                    
                }
            }
            foreach (ElementarySchool school in allSchool)
            {
                if (school.ZipCode != null)
                {
                    newSchool = school;
                }
            }
            ViewData["Houses"] = houseNearSchool;
            ViewData["School"] = newSchool;
            SearchCompleted = true;
        }
        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }
    }
}