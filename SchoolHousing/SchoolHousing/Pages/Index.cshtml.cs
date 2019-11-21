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
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

public class IndexModel : PageModel
{
    public string DownloadData(string jsonendpoint)
    {
        string rawData = "";
        using (WebClient webClient = new WebClient())
        {
            rawData = webClient.DownloadString(jsonendpoint);
        }
        return rawData;
    }

    public void OnGet()
    {
        using (var webClient = new WebClient())
        {
            IDictionary<long, AffordableHouseResponse.AffordableHouse> allHouses = new Dictionary<long, AffordableHouseResponse.AffordableHouse>();
            string houseString = DownloadData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            AffordableHouseResponse.AffordableHouse[] afHouses = AffordableHouseResponse.AffordableHouse.FromJson(houseString);
            foreach (AffordableHouseResponse.AffordableHouse house in afHouses)
            {
                if (allHouses.ContainsKey(house.ZipCode))
                {
                    //do nothing
                }
                else
                {
                    allHouses.Add(house.ZipCode, house);
                }
                
            }
            var houseData = AffordableHouse.FromJson(houseString);
            ViewData["AffordableHouse"] = houseData;
            
            string schoolString = DownloadData("https://data.cityofchicago.org/resource/tj8h-mnuv.json");
            ElementarySchoolResponse.ElementarySchool[] elemSchool = ElementarySchoolResponse.ElementarySchool.FromJson(schoolString);
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("ElementarySchoolSchema.json"));
            JArray jsonArray = JArray.Parse(schoolString);
            dynamic data = JObject.Parse(jsonArray[0].ToString());
            var schoolData = ElementarySchool.FromJson(schoolString);
            ViewData["ElementarySchool"] = schoolData;
            IList<string> validationEvents = new List<string>();
            if (jsonArray.IsValid(schema, out validationEvents))
            {
                Console.WriteLine("Validated");
            }
            else
            {
                foreach (string evt in validationEvents)
                {
                    Console.WriteLine(evt);
                }
                ViewData["ElementarySchoolValidated"] = new List<ElementarySchool>();
            }
            
            

        }
    }
}