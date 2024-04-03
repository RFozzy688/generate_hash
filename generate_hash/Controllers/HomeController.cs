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

        public HomeController(IHashService hashService, IKdfService kdfService)
        {
            _hashService = hashService;
            _kdfService = kdfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult IoC()
        {
            HomeIocPageModel model = new()
            {
                HashVerificationCode = _hashService.Digest(_random.Next(100, 200).ToString()).ToLower().Remove(6),
                HashFileName = _hashService.Digest(_random.Next(1, 100).ToString()).ToLower().Remove(10),
                KdfCryptoSalt = _kdfService.GetDerivedKey(_random.Next().ToString(), _random.Next().ToString())
            };

            return View(model);
        }
    }
}
