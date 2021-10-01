using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PdfDemo.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace PdfDemo.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(
            IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public string OpenFile(string path)
        {
            path = Path.Combine(_hostingEnvironment.ContentRootPath, path);

            byte[] b = System.IO.File.ReadAllBytes(path);
            return Convert.ToBase64String(b);
        }
    }
}
