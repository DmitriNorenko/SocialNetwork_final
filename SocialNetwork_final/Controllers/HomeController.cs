using Microsoft.AspNetCore.Mvc;
using SocialNetwork_final.DB.Model;
using SocialNetwork_final.DB.Repository;
using SocialNetwork_final.Models;
using System.Diagnostics;

namespace SocialNetwork_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Age = 23,
                Email = "Test@gmail.com"
            };
            _userRepository.AddUser(user);
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
    }
}
