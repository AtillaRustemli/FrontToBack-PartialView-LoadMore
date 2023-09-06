using FrontToBack_PartialView_LoadMore.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.DAL
{
    public class AppDbContext : DbContext
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

    }
}
