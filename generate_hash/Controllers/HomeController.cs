using generate_hash.Models;
using generate_hash.Models.Home;
using generate_hash.Services.Hash;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace generate_hash.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHashService _hashService;

        public HomeController(IHashService hashService)
        {
            _hashService = hashService;
        }

        public IActionResult Index()
        {
            ViewBag.VerificationCode = TempData["VerificationCode"];
            return View();
        }

        [HttpPost]
        public IActionResult GenerateVerificationCode()
        {
            int random = new Random().Next(100, 200);
            HomeIocPageModel model = new HomeIocPageModel();
            model.HashExample = _hashService.Digest(random);
            TempData["VerificationCode"] = model.HashExample.ToLower().Remove(6);

            return RedirectToAction("Index");
        }
    }
}
