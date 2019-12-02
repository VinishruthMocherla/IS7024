using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AffordableHouseResponse;
using System.Net;

namespace SchoolHousing.Controllers
{
    [Route("api")]
    [ApiController]
    public class HousingSchoolController : ControllerBase
    {
        public AffordableHouseResponse.AffordableHouse[] houses;
        public AffordableHouseResponse.AffordableHouse[] housesFiltered;
        [HttpGet]
        [Route("GetHousingData/{zipcode}")]
        public ActionResult<AffordableHouse[]> Get(int zipCode)
        {
            using (var webClient = new WebClient())
            {
                String houseJSON = webClient.DownloadString("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
                houses = AffordableHouse.FromJson(houseJSON);
                housesFiltered = houses.Where(x => x.ZipCode == zipCode).ToArray();
                return housesFiltered;
            }
        }
    }
}