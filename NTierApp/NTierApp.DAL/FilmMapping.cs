using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.DAL
{
    public class FilmMapping : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.Property(x => x.FilmAdi).IsRequired().HasMaxLength(100);

            builder.ToTable("Filmler");

            builder.HasOne(x => x.FilmKategori)
                .WithMany(x => x.Filmler)
                .HasForeignKey(x => x.KategoriID);

            builder.HasOne(x => x.FilmDetay)
                .WithOne(x => x.Film)
                .HasForeignKey<FilmDetay>(x => x.FilmID);
        }
    }
}
