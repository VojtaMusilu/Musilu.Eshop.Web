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


namespace Musilu.Eshop.Web.Areas.Home.Controllers
{ 
    public class ProductController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;
        public IActionResult Detail(int id)
        {
            Product pi = eshopDbContext.Products.FirstOrDefault(p => p.ID == id);
            return View(pi);
        }
    }
}