using Microsoft.AspNetCore.Mvc;
using Musilu.Eshop.Web.Controllers;
using Musilu.Eshop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = "" });
            }
            return View(registerVM);
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = "" });
            }
            return View(loginVM);
        }

    }
}
