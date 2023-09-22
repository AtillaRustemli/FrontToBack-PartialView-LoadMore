using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Entities.DemoEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<SliderContent> SliderContent { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<AboutList> AboutList { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { 
                    Id=Guid.NewGuid().ToString(),
                    Name="Admin",
                    NormalizedName="ADMIN",
                    ConcurrencyStamp= Guid.NewGuid().ToString()

                }, new IdentityRole { 
                    Id=Guid.NewGuid().ToString(),
                    Name="SuperAdmin",
                    NormalizedName= "SUPERADMIN",
                    ConcurrencyStamp= Guid.NewGuid().ToString()

                }, new IdentityRole { 
                    Id=Guid.NewGuid().ToString(),
                    Name="Member",
                    NormalizedName="MEMBER",
                    ConcurrencyStamp= Guid.NewGuid().ToString()

                }
                );

        }

    }
}
