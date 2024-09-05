using Microsoft.EntityFrameworkCore;
using NTierApp.Domain;

namespace NTierApp.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=UMIT;Initial Catalog=FilmDB;User ID=test_user;Password=1234567890;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FilmMapping().Configure(modelBuilder.Entity<Film>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Film> Filmler { get; set; }
        public DbSet<FilmDetay> FilmDetaylar { get; set; }
        public DbSet<FilmKategori> FilmKategoriler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<OyuncuFilm> OyuncuFilmler { get; set; }
    }
}
