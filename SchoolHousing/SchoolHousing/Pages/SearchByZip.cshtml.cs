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
        public bool searchFinished { get; set; }
        [BindProperty]
        public long ZipSearch { get; set; }
        public  AffordableHouseResponse.AffordableHouse[] houses;
        public ElementarySchoolResponse.ElementarySchool[] schools;
        public AffordableHouseResponse.AffordableHouse[] housesFiltered;
        public ElementarySchoolResponse.ElementarySchool[] schoolsFiltered;
        public void OnGet()
        {

        }


        public void OnPost()
        {

            using (var webClient = new WebClient())
            {
                String schoolJSON = webClient.DownloadString("https://data.cityofchicago.org/resource/tj8h-mnuv.json");
                schools = ElementarySchool.FromJson(schoolJSON);


                String houseJSON = webClient.DownloadString("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
                houses = AffordableHouse.FromJson(houseJSON);

                housesFiltered = houses.Where(x => x.ZipCode == ZipSearch).ToArray();
                schoolsFiltered = schools.Where(x => x.ZipCode == ZipSearch).ToArray();

                ViewData["AffordableHouses"] = housesFiltered;
                ViewData["ElementarySchools"] = schoolsFiltered;
            }
            searchFinished = true;
        }
    }
}