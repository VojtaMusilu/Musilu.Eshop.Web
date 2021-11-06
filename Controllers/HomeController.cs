using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Musilu.Eshop.Web.Models;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.CarouselItems = DatabaseFake.CarouselItems;
            
            
            return View(indexVM);
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
