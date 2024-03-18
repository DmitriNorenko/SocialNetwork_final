using AutoMapper;
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
        private IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository,IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
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
        public async Task<IActionResult> AddUser([FromBody] UserRequest user)
        {
            var newUser = _mapper.Map<UserRequest,User>(user);
            _userRepository.AddUser(newUser);
            return  StatusCode(200,$"����� ������������ {newUser.Name} ��������!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
