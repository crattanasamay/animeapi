using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyAnimeAPI.Models;

namespace MyAnimeAPI.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

            public DbSet<Anime> Anime { get; set; }


            public DbSet<UserAnime> UserAnime { get; set; }

    }
    
}
