using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Musilu.Eshop.Web.Models;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.ViewModels;


namespace Musilu.Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            _logger = logger;
            eshopDbContext = eshopDB;
            this.env = env;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Loaded Home Index");
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.CarouselItems = eshopDbContext.CarouselItems.ToList();
            indexVM.Products = eshopDbContext.Products.ToList();

            //IList<CarouselItem> carouselItems = DatabaseFake.CarouselItems;


            //return View(carouselItems);
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
