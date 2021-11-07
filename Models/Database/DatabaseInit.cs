using Musilu.Eshop.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Models.Database
{
    public class DatabaseInit
    {
        public void Initialization(EshopDbContext eshopDbContext)
        {
            eshopDbContext.Database.EnsureCreated();

            if (eshopDbContext.CarouselItems.Count() == 0)
            {
                IList<CarouselItem> cItems = GenerateCarouselItems();
                foreach (CarouselItem cItem in cItems)
                {
                    eshopDbContext.Add(cItem);
                }
                eshopDbContext.SaveChanges();
            }
        }


        public List<CarouselItem> GenerateCarouselItems()
        {
            List<CarouselItem> carouselItems = new List<CarouselItem>();

            CarouselItem ci1 = new CarouselItem() { ImageSource = @"\img\1.jpg", ImageAlt = "First slide" };
            CarouselItem ci2 = new CarouselItem() { ImageSource = @"\img\2.jpg", ImageAlt = "Second slide" };
            CarouselItem ci3 = new CarouselItem() { ImageSource = @"\img\3.jpg", ImageAlt = "Third slide" };

            carouselItems.Add(ci1);
            carouselItems.Add(ci2);
            carouselItems.Add(ci3);

            return carouselItems;
        }
        public List<Product> GenerateProducts()
        {
            List<Product> Products = new List<Product>();

            Product p1 = new Product() { Name = "phone", Category = "electronics", ImageSource = @"\img\products\1.jpg" };
            Product p2 = new Product() { Name = "phone 2", Category = "electronics" };
            Product p3 = new Product() { Name = "shirt", Category = "clothes" };

            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);

            return Products;
        }


    }
}