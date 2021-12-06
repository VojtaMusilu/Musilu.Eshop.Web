using Musilu.Eshop.Web.Models.ApplicationServices.Abstraction;
using Musilu.Eshop.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musilu.Eshop.Web.Areas.Admin.Controllers;

namespace Musilu.Eshop.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        ISecurityApplicationService security;


        public AccountController(ISecurityApplicationService security)
        {
            this.security = security;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                string[] errors = await security.Register(registerVM, Models.Identity.Roles.Customer);
                if (errors != null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };
                    bool isLogged = await security.Login(loginVM);

                    if (isLogged)
                    {
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty), new { area = string.Empty });
                    }
                    else
                    {
                        RedirectToAction(nameof(Login));
                    }
                }

            }
            return View(registerVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await security.Login(loginVM);

                if (isLogged)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty), new { area = string.Empty });
                }
                loginVM.LoginFailed = true;
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await security.Logout();
            return RedirectToAction(nameof(Login));
        }

    }
}
