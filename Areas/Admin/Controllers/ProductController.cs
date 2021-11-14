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
        


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product != null && product.Image != null)
            {
                FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/ProductItems", "image");
                product.ImageSource = await fileUpload.FileUploadAsync(product.Image);
                if (String.IsNullOrWhiteSpace(product.ImageSource) == false)
                {
                    
                    eshopDbContext.Products.Add(product);
                    await eshopDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(ProductController.Select));
                }
            }

            return View(product);
        }
        public IActionResult Edit(int ID)
        {
            Product product = eshopDbContext.Products.FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product newProduct)
        {
            Product product = eshopDbContext.Products.FirstOrDefault(ci => ci.ID == newProduct.ID);
            if (product != null)
            {

                if (newProduct != null && newProduct.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/ProductItems", "image");
                    newProduct.ImageSource = await fileUpload.FileUploadAsync(newProduct.Image);

                    if (String.IsNullOrWhiteSpace(newProduct.ImageSource) == false)
                    {
                        product.ImageSource = newProduct.ImageSource;
                    }
                }
                product.ImageAlt = newProduct.ImageAlt;
                product.Name = newProduct.Name;
                product.Category = newProduct.Category;
                product.Price = newProduct.Price;
                product.Description = newProduct.Description;
                await eshopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ProductController.Select));
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

            return RedirectToAction(nameof(CarouselController.Select));
        }
    }
}
