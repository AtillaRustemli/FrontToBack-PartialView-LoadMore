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

    }
}
