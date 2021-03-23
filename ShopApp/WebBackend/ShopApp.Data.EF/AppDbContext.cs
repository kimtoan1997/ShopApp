using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShopApp.Data.EF.Configurations;
using ShopApp.Data.EF.Extensions;
using ShopApp.Data.Entities;
using ShopApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShopApp.Data.EF
{
    public class AppDbContext :IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole>   AppRoles { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUsers { get; set;}
        public  DbSet<Blog> Blogs { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }
        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId});
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId});
            #endregion

            builder.AddConfiguration(new TagConfiguration());
            builder.AddConfiguration(new BlogTagConfiguration());
            builder.AddConfiguration(new ContactDetailConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new PageConfiguration());
            builder.AddConfiguration(new ProductTagConfiguration());
            builder.AddConfiguration(new SystemConfigConfiguration());
            builder.AddConfiguration(new AdvertistmentPositionConfiguration());
            builder.AddConfiguration(new AdvertistmentPageConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new AdvertistmentConfiguration());
            builder.AddConfiguration(new AnnouncementConfiguration());
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            
            foreach(EntityEntry item in modified)
            {
                var changedOrAddedItem = item as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionBuilders = new DbContextOptionsBuilder();
            var connectionString = configuration.GetConnectionString("AppConnection");
            optionBuilders.UseSqlServer(connectionString);
            return new AppDbContext(optionBuilders.Options);
        }
    }
}
