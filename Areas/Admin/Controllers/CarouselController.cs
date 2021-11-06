using Microsoft.AspNetCore.Mvc;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {

        readonly EshopDbContext eshopDbContext;
        public CarouselController(EshopDbContext eshopDb)
        {
            eshopDbContext = eshopDb;
        }


        public IActionResult Select()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.CarouselItems = eshopDbContext.CarouselItems.ToList();

            return View(indexVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarouselItem carouselItem)
        {
            if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false
                && String.IsNullOrWhiteSpace(carouselItem.ImageAlt) == false)
            {
                eshopDbContext.CarouselItems.Add(carouselItem);
                await eshopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(CarouselController.Select));
            }
            else
            {
                return View(carouselItem);
            }
        }

        public IActionResult Edit(int ID)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.FirstOrDefault(ci => ci.ID == ID);

            if (carouselItem != null)
            {
                return View(carouselItem);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarouselItem cItem)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.FirstOrDefault(ci => ci.ID == cItem.ID);

            if (carouselItem != null)
            {

                if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false
                    && String.IsNullOrWhiteSpace(carouselItem.ImageAlt) == false)
                {
                    carouselItem.ImageSource = cItem.ImageSource;
                    carouselItem.ImageAlt = cItem.ImageAlt;
                    await eshopDbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(CarouselController.Select));
                }
                else
                {
                    return View(carouselItem);
                }
            }

            return NotFound();
        }


        public async Task<IActionResult> Delete(int ID)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.FirstOrDefault(ci => ci.ID == ID);

            if (carouselItem != null)
            {
                eshopDbContext.CarouselItems.Remove(carouselItem);
                await eshopDbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(CarouselController.Select));
        }
    }
}