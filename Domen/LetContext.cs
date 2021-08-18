using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
   public  class LetContext:DbContext
    {
        public DbSet<Let> Let{ get; set; }
        public DbSet<Korisnik> Korisnik{ get; set; }
        public DbSet<Rezervacija> Rezervacija{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Letovi;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervacija>()
            .HasKey(r => new { r.LetId, r.KorisnikId});

            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.Korisnik)
                .WithMany(r => r.Rezervacija)
                .HasForeignKey(r => r.KorisnikId);

            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.Let)
                .WithMany(r => r.Rezervacija)
                .HasForeignKey(r => r.LetId);
        }
    }
}
