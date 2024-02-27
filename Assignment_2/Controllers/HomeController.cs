using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiKey = "b96b7755de718a1b432606c6d78ebd2c";
        private readonly string baseUrl = "http://api.openweathermap.org/data/2.5/weather";

        public ActionResult Index()
        {
             async Task<string> GetWeatherAsync(string city)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"{baseUrl}?q={city}&appid={apiKey}");
                    return await response.Content.ReadAsStringAsync();
                }
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}