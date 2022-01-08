using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Implementation;
using Microsoft.Extensions.Logging;

namespace Musilu.Eshop.Web.Controllers
{ 
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        readonly EshopDbContext eshopDbContext;

        public ProductController(ILogger<ProductController> logger, EshopDbContext eshopDb)
        {
            _logger = logger;
            eshopDbContext = eshopDb;
        }

        public IActionResult Detail(int id)
        {
            Product pi = eshopDbContext.Products.FirstOrDefault(p => p.ID == id);

            if (pi != null)
            {
                return View(pi);
            }
            else
            {
                return NotFound();
            }
        }
    }
}