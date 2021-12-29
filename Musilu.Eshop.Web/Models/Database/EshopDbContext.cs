using Musilu.Eshop.Web.Models.Database.Configuration;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Models.Database
{
	public class EshopDbContext : IdentityDbContext<User, Role, int>
	{
		public DbSet<CarouselItem> CarouselItems { get; set; }
		public DbSet<Product> Products { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Order> Orders { get; set; }

		public EshopDbContext(DbContextOptions options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			builder.ApplyConfiguration<Order>(new OrderConfiguration());

			foreach (var entity in builder.Model.GetEntityTypes())
				{
				entity.SetTableName(entity.GetTableName().Replace("AspNet", string.Empty));
			}
        }
    }
}