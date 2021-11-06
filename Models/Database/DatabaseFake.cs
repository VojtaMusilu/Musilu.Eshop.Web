using Musilu.Eshop.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Models.Database
{
    public static class DatabaseFake
    {
        public static List<CarouselItem> CarouselItems { get; set; }
        public static List<Product> Products { get; set; }


        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();

            CarouselItems = dbInit.GenerateCarouselItems();
            Products = dbInit.GenerateProducts();
        
        }

    }
}
