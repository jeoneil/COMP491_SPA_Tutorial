using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using SPA_Tutorial.DataTest;
using Newtonsoft.Json;

namespace SPA_Tutorial.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> About([FromServices] INodeServices nodeServices)
        {
            var options = new { width = 400, height = 200, showArea = true, showPoint = true, fullWidth = true };
            //    var data = new
            //    {
            //        labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" },
            //        series = new[] {
            //    new[] { 1, 5, 2, 5, 4, 3 },
            //    new[] { 2, 3, 4, 8, 1, 2 },
            //    new[] { 5, 4, 3, 2, 1, 0 }
            //}
            //    };

            // This emulates some fetching of a JSON from an API. 
            MyData hmm = new MyData();
            string json = hmm.MakeData();

            var data = JsonConvert.DeserializeObject(json);

            //ViewData["json"] = json;
            ViewData["ChartMarkup"] = await nodeServices.InvokeAsync<string>("myNodeModule.js", "line", options, data);

            return View();
        }
    }
}
