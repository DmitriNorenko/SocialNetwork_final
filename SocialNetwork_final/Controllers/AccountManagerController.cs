using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork_final.DB.Model;
using SocialNetwork_final.Models;
using SocialNetwork_final.ViewModels.Account;
using SocialNetwork_final.ViewModels;
using System;

namespace SocialNetwork_final.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountManagerController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View("Views/Home/Index.cshtml");
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = _mapper.Map<User>(model);

                var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("MyPage", "AccountManager");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View("Views/Home/Index.cshtml");
        }

        [Route("MyPage")]
        [HttpGet]
        public IActionResult MyPage()
        {
            var user = _userManager.FindByEmailAsync(_signInManager.Context.User.Identity.Name).Result;
            UserViewModel ViewUser = new UserViewModel(user);
            return View(ViewUser);
        }

        [Route("PageUpdate")]
        [HttpGet]
        public IActionResult PageUpdate()
        {
            var user = User;
            var result = _userManager.GetUserAsync(user);
            return View(result.Result);
        }

        [Route("PageUpdate")]
        [HttpPost]
        public async Task<IActionResult> PageUpdate(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                user.Convert(model);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("MyPage", "AccountManager");
                }
                else
                {
                    return RedirectToAction("Logout", "AccountManager");
                }
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View("Logout", model);
            }
        }

        [Route("UserList")]
        [HttpPost]
        public IActionResult UserList(string search)
        {
            var model = new SearchViewModel
            {
                UserList = _userManager.Users.AsEnumerable().Where(x => x.GetFullName().ToLower().Contains(search.ToLower())).ToList()
            };
            return View("UserList",model);
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
