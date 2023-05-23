using Code_Test_MVC_application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Code_Test_MVC_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListingPage()
        {
            IEnumerable<Colleges> colleges = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://universities.hipolabs.com");
                //HTTP GET
                var responseTask = client.GetAsync("/search?country=canada");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    colleges = JsonConvert.DeserializeObject<List<Colleges>>(result.Content.ReadAsStringAsync().Result);
                    //var stuff = JsonConvert.DeserializeObject<List<Colleges>>(result.Content.ReadAsStringAsync().Result);
                }
                else //web api sent error response 
                {
                    //log response status here..

                    colleges = Enumerable.Empty<Colleges>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            colleges = colleges.Where(x => x.name.ToLower() == "university of toronto");
            return View(colleges);
        }

        public IActionResult ContactUs()
        { 
            Contacts newContact = new Contacts();
            return View(newContact);
            


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}