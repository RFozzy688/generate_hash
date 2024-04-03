using generate_hash.Models;
using generate_hash.Models.Home;
using generate_hash.Services.Hash;
using generate_hash.Services.Kdf;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace generate_hash.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHashService _hashService;
        private readonly IKdfService _kdfService;
        Random _random = new Random();
        HomeIocPageModel _model = new HomeIocPageModel();

        public HomeController(IHashService hashService, IKdfService kdfService)
        {
            _hashService = hashService;
            _kdfService = kdfService;
        }

        public IActionResult Index()
        {
            ViewBag.VerificationCode = TempData["VerificationCode"];
            ViewBag.FileName = TempData["FileName"];
            ViewBag.CryptoSalt = TempData["CryptoSalt"];

            return View();
        }

        [HttpPost]
        public IActionResult GenerateVerificationCode()
        {
            _model.HashExample = _hashService.Digest(_random.Next(100, 200).ToString());
            TempData["VerificationCode"] = _model.HashExample.ToLower().Remove(6);

            return RedirectToAction("Index");
        }

        public IActionResult GenerateFileName()
        {
            _model.HashExample = _hashService.Digest(_random.Next(1, 200).ToString());
            TempData["FileName"] = _model.HashExample.ToLower().Remove(10);

            return RedirectToAction("Index");
        }

        public IActionResult GenerateCryptoSalt()
        {
            _model.KdfExample = _kdfService.GetDerivedKey(_random.Next(1, 200).ToString(),
                _random.Next(1, 200).ToString());

            TempData["CryptoSalt"] = _model.KdfExample;

            return RedirectToAction("Index");
        }
    }
}
