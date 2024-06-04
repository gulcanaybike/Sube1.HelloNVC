using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sube1.EntityApp
{
    internal class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source= .; Initial Catalog=OkulDbEf; user=sa; password=abc123; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler"); //table adını belirlememizi sağlar
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();//propertyleri özelleştirmke için
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        }
    }
}
//Dbcontext: entity frame work de veri tabanı işlemleri yapılı savechanges gibi metodlar vardır sql kodu yazmadan bu işlemleri yapmamızı sağlar
//entity framework tools entity de code first migration işlemlerini yapmamızı sağlar
//dbset:veritabanı tablolarını temsil eder ram de oluşturulur generictir birden fazla öğrenci tutmayı sağlar chnagetarcking ile çalışır bundan kasıt entitystate dbset içindeki verilerin durumlarını tutar modifed, inserted, added added --> savechnages() --> inserted(veritabanına kaydedilir) 
//onconfiguring: connectionstring tanımlanır
//migration işlemi: pacakge manager console --> add-migration InitDb(ismi) --> update-database proje de derleme hatası olmamalı çalışması için
//initdb içinde migration dan kalıtım alır up(): ram de aldığı bilgileri veritabanın da tabloyu oluştuur migrationBuilder.CreateTable dbset'e bakrak kolnonları oluşturu ve dbsetin adını verir tabloya 
//otomatik olarak id olarak kolnu tanımlaması için ya sadece id ya da class adı id yani Ogrenciid
//constraint kısıtlayıcılar table.PrimaryKey() primarykeyi tanımlar
//down(): DropTable: tabloyu siler
//fluentapi onmodelcraeting: model oluşturulurken tablo alanları özelleştirmemizi sağlar zincir yapısı gibi . ile devam ediyoruz sütunları özelleştirmemizi sağlar
//bir migration'ı geri almak için remove-migration komutu kullanılır. bu migration classında bulunan down metodunu çalıştırır.
//ikinci bir migartion ekledik add-migration ColumnProperties tekrardan update-database dedik
//attribute kullanımı Ders classında dataannotaions 
//sql server profiler yapılan işlemleri gösterir tracking yapar
//crud dispose migration 