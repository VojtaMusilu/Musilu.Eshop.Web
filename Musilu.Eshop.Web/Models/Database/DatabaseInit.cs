using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

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
            
            if (eshopDbContext.Products.Count() == 0)
            {
                IList<Product> ps = GenerateProducts();
                foreach (Product p in ps)
                {
                    eshopDbContext.Add(p);
                }
                eshopDbContext.SaveChanges();
            }
        }


        public List<CarouselItem> GenerateCarouselItems()
        {
            List<CarouselItem> carouselItems = new List<CarouselItem>();

            CarouselItem ci1 = new CarouselItem() { ImageSource = @"\img\CarouselItems\1.jpg", ImageAlt = "First slide" };
            CarouselItem ci2 = new CarouselItem() { ImageSource = @"\img\CarouselItems\2.jpg", ImageAlt = "Second slide" };
            CarouselItem ci3 = new CarouselItem() { ImageSource = @"\img\CarouselItems\3.jpg", ImageAlt = "Third slide" };

            carouselItems.Add(ci1);
            carouselItems.Add(ci2);
            carouselItems.Add(ci3);

            return carouselItems;
        }
        public List<Product> GenerateProducts()
        {
            List<Product> Products = new List<Product>();

            Product p1 = new Product() { Name = "phone", Category = "electronics", ImageSource = @"\img\ProductItems\phone1.jpg", Description = "great phone very fast super pretty buy it pls", Price = 10000 };
            Product p2 = new Product() { Name = "phone 2", Category = "electronics", ImageSource = @"\img\ProductItems\phone2.jpg", Description = "greatest phone even faster much prettier buy it pls", Price = 20000 };
            Product p3 = new Product() { Name = "shirt", Category = "clothes", ImageSource = @"\img\ProductItems\shirt1.jpg", Description = "a bad shirt. dont buy it", Price = 100 };
            Product p4 = new Product() { Name = "another shirt", Category = "clothes", ImageSource = @"\img\ProductItems\shirt2.jpg", Description = "worst shirt ever. dont even look at it", Price = 20 };
            Product p5 = new Product() { Name = "tissues", Category = "toiletries", ImageSource = @"\img\ProductItems\tissues.jpg", Description = "to wipe your tears after spending so much money on those phones only to realize theyre actually bad", Price = 35 };

            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);
            Products.Add(p5);

            return Products;
        }


        public async Task EnsureRoleCreated(RoleManager<Role> roleManager)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new Role(role));
            }
        }

        public async Task EnsureAdminCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "admin",
                Email = "admin@admin.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni"
            };
            string password = "abc";

            User adminInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (adminInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Admin: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureManagerCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "manager",
                Email = "manager@manager.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni"
            };
            string password = "abc";

            User managerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (managerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role != Roles.Admin.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Manager: {error.Code}, {error.Description}");
                    }
                }
            }

        }

    }
}