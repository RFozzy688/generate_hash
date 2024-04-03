using generate_hash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace generate_hash.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
