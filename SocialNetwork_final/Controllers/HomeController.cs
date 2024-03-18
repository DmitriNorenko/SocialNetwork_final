using Microsoft.AspNetCore.Mvc;
using SocialNetwork_final.Contract.Model.Request;
using SocialNetwork_final.Contract.Validator;
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserRequest user)
        {
            return StatusCode(200,user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
