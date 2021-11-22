using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Identity;
using System;

namespace Musilu.Eshop.Web.Models.Database
{
	public class EshopDbContext : IdentityDbContext<User, Role, int>
	{
		public DbSet<CarouselItem> CarouselItems { get; set; }
		public DbSet<Product> Products { get; set; }

		public EshopDbContext(DbContextOptions options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



			foreach (var entity in builder.Model.GetEntityTypes())
				{
				entity.SetTableName(entity.GetTableName().Replace("AspNet", string.Empty));
			}
        }
    }
}