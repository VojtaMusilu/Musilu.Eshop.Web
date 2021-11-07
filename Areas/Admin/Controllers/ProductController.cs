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

namespace Musilu.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;
        public ProductController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }
        public IActionResult Select()
        {
            IList<Product> carouselItems = eshopDbContext.Products.ToList();
            return View(carouselItems);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Product pi = eshopDbContext.Products.FirstOrDefault(p => p.ID == id);
            return View(pi);
        }

        /*
        [HttpPost]
        public IActionResult Create(ProductItem carouselItem)
        {
            if (carouselItem != null && carouselItem.Image != null && carouselItem.Name != null/* && carouselItem.Price != null*///)
        /*{
            //if (DatabaseFake.CarouselItems != null && DatabaseFake.CarouselItems.Count > 0)
            {
                carouselItem.ID = DatabaseFake.CarouselItems.Last().ID + 1;
            }
            ProductsFake.CarouselItems.Add(carouselItem);
            return RedirectToAction(nameof(ProductController.Select));
        }
        else
        {
            return View(carouselItem);
        }
    }
        */
        /*
        public IActionResult Edit(int ID)
        {
            ProductItem cifromDb = ProductsFake.CarouselItems.FirstOrDefault(ci => ci.ID == ID);
            if (cifromDb != null)
            {
                return View(cifromDb);
            }
            else
            {
                return NotFound();
            }

        }*/

        /*
        [HttpPost]
        public IActionResult Edit(ProductItem carouselItem)
        {
            ProductItem cifromDb = ProductsFake.CarouselItems.FirstOrDefault(ci => ci.ID == carouselItem.ID);
            if (cifromDb != null)
            {
                cifromDb.ImageSource = carouselItem.ImageSource;
                cifromDb.Name = carouselItem.Name;
                cifromDb.Price = carouselItem.Price;

                return RedirectToAction(nameof(CarouselController.Select));
            }
            else
            {
                return NotFound();
            }
        }
        */

        /*
        public IActionResult Delete(int ID)
        {
            IList<ProductItem> carouselItems = ProductsFake.CarouselItems;
            ProductItem ci = carouselItems.Where(CarouselItem => CarouselItem.ID == ID).FirstOrDefault();
            if (ci != null)
            {
                carouselItems.Remove(ci);
            }
            //return View();
            return RedirectToAction(nameof(CarouselController.Select));
        }*/

        [HttpPost]
        public async Task<IActionResult> Create(Product carouselItem)
        {
            if (carouselItem != null && carouselItem.Image != null)
            {
                FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/ProductItems", "image");
                carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);
                if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false)
                {
                    /*if(eshopDbContext.CarouselItems!=null && eshopDbContext.CarouselItems.Count > 0)
                    {
                        carouselItem.ID = eshopDbContext.CarouselItems.Last().ID + 1;
                    }*/
                    eshopDbContext.Products.Add(carouselItem);
                    await eshopDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(ProductController.Select));
                }
            }
            /*
            else
            {
            }*/
            return View(carouselItem);
        }
        public IActionResult Edit(int ID)
        {
            Product cifromDb = eshopDbContext.Products.FirstOrDefault(ci => ci.ID == ID);
            if (cifromDb != null)
            {
                return View(cifromDb);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product carouselItem)
        {
            Product cifromDb = eshopDbContext.Products.FirstOrDefault(ci => ci.ID == carouselItem.ID);
            if (cifromDb != null)
            {

                if (carouselItem != null && carouselItem.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/ProductItems", "image");
                    carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);

                    if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false)
                    {
                        cifromDb.ImageSource = carouselItem.ImageSource;
                    }
                }
                cifromDb.ImageAlt = carouselItem.ImageAlt;
                cifromDb.Name = carouselItem.Name;
                cifromDb.Price = carouselItem.Price;
                await eshopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(CarouselController.Select));
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> Delete(int ID)
        {
            DbSet<Product> carouselItems = eshopDbContext.Products;
            Product ci = carouselItems.Where(CarouselItem => CarouselItem.ID == ID).FirstOrDefault();
            if (ci != null)
            {
                carouselItems.Remove(ci);
                await eshopDbContext.SaveChangesAsync();
            }
            //return View();
            return RedirectToAction(nameof(CarouselController.Select));
        }
    }
}
