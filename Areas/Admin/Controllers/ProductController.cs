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
    public class ProductController : Controller
    {


        public IActionResult Select()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.Products = DatabaseFake.Products;


            return View(indexVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (String.IsNullOrWhiteSpace(product.ImageSource) == false
                && String.IsNullOrWhiteSpace(product.Category) == false
                && String.IsNullOrWhiteSpace(product.Name) == false)
            {
                if (DatabaseFake.Products != null && DatabaseFake.Products.Count > 0)
                {
                    product.ID = DatabaseFake.Products.Last().ID + 1;
                }

                DatabaseFake.Products.Add(product);
                return RedirectToAction(nameof(ProductController.Select));
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Edit(int ID)
        {
            Product product = DatabaseFake.Products.FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product pr)
        {
            Product product = DatabaseFake.Products.FirstOrDefault(p => p.ID == pr.ID);
            if (product != null)
            {
                if (String.IsNullOrWhiteSpace(product.ImageSource) == false
                    && String.IsNullOrWhiteSpace(product.Name) == false
                    && String.IsNullOrWhiteSpace(product.Category) == false)
                {
                    product.ImageSource = pr.ImageSource;
                    product.Name = pr.Name;
                    product.Category = pr.Category;
                    return RedirectToAction(nameof(ProductController.Select));
                }
                else
                {
                    return View(product);
                }

            }

            return NotFound();
        }

        public IActionResult Delete(int ID)
        {

            Product product = DatabaseFake.Products.FirstOrDefault(p => p.ID == ID);

            if (product != null)
            {
                DatabaseFake.Products.Remove(product);
            }

            return RedirectToAction(nameof(ProductController.Select));
        }
    }
}