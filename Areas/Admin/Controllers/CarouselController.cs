using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Implementation;
using Musilu.Eshop.Web.Models.Identity;

namespace Musilu.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;
        public CarouselController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }
        public IActionResult Select()
        {
            IList<CarouselItem> carouselItems = eshopDbContext.CarouselItems.ToList();
            return View(carouselItems);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarouselItem carouselItem)
        {

            FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/CarouselItems", "image");
            if (fileUpload.CheckFileContent(carouselItem.Image) && fileUpload.CheckFileLength(carouselItem.Image))
            {
                carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);
                ModelState.Clear();
                TryValidateModel(carouselItem);
                if (ModelState.IsValid)
                {
                    eshopDbContext.CarouselItems.Add(carouselItem);
                    await eshopDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(CarouselController.Select));
                }
            }
            return View(carouselItem);

        }
        public IActionResult Edit(int ID)
        {
            CarouselItem cifromDb = eshopDbContext.CarouselItems.FirstOrDefault(ci => ci.ID == ID);
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
        public async Task<IActionResult> Edit(CarouselItem cItem)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.FirstOrDefault(ci => ci.ID == cItem.ID);
            if (carouselItem != null)
            {

                if (cItem != null && cItem.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/CarouselItems", "image");

                    if (fileUpload.CheckFileContent(cItem.Image) && fileUpload.CheckFileLength(cItem.Image))
                    {
                        cItem.ImageSource = await fileUpload.FileUploadAsync(cItem.Image);
                        carouselItem.ImageSource = cItem.ImageSource;
                    }
                }
                else
                {
                    cItem.ImageSource = "-";
                }

                ModelState.Clear();
                TryValidateModel(carouselItem);

                if (ModelState.IsValid)
                {
                    carouselItem.ImageAlt = cItem.ImageAlt;
                    await eshopDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(CarouselController.Select));
                }

                return NotFound();

            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> Delete(int ID)
        {
            DbSet<CarouselItem> carouselItems = eshopDbContext.CarouselItems;
            CarouselItem ci = carouselItems.Where(CarouselItem => CarouselItem.ID == ID).FirstOrDefault();
            if (ci != null)
            {
                carouselItems.Remove(ci);
                await eshopDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(CarouselController.Select));
        }
    }
}
