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