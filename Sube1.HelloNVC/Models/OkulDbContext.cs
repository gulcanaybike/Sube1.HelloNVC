using Microsoft.EntityFrameworkCore;

namespace Sube1.HelloNVC.Models
{
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        public DbSet<OgrenciDers> ogrenciDersler {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source= .; Initial Catalog=OkulDbSube1Mvc; user=sa; password=abc123; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(d => d.Dersad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.DersKodu).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OgrenciDers>().ToTable("tblOgrneciDersleri");
            modelBuilder.Entity<OgrenciDers>().HasKey(og => new { og.Ogrenciid, og.Dersid });
            modelBuilder.Entity<OgrenciDers>().HasOne(og => og.Ogrenci).WithMany(o => o.OgrenciDersleri).HasForeignKey(og => og.Ogrenciid);
            modelBuilder.Entity<OgrenciDers>().HasOne(og => og.ders).WithMany(d => d.OgrenciDersleri).HasForeignKey(og => og.Dersid);
        }
    }
}
