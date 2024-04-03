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
        Random _random = new Random();
        HomeIocPageModel _model = new HomeIocPageModel();

        public HomeController(IHashService hashService)
        {
            _hashService = hashService;
        }

        public IActionResult Index()
        {
            ViewBag.VerificationCode = TempData["VerificationCode"];
            ViewBag.FileName = TempData["FileName"];

            return View();
        }

        [HttpPost]
        public IActionResult GenerateVerificationCode()
        {
            _model.HashExample = _hashService.Digest(_random.Next(100, 200));
            TempData["VerificationCode"] = _model.HashExample.ToLower().Remove(6);

            return RedirectToAction("Index");
        }

        public IActionResult GenerateFileName()
        {
            _model.HashExample = _hashService.Digest(_random.Next(1, 200));
            TempData["FileName"] = _model.HashExample.ToLower().Remove(10);

            return RedirectToAction("Index");
        }
    }
}
