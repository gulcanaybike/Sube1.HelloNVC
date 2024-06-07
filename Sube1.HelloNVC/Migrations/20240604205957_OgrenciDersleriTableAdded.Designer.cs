﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sube1.HelloNVC.Models;

#nullable disable

namespace Sube1.HelloNVC.Migrations
{
    [DbContext(typeof(OkulDbContext))]
    [Migration("20240604205957_OgrenciDersleriTableAdded")]
    partial class OgrenciDersleriTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sube1.HelloNVC.Models.Ders", b =>
                {
                    b.Property<int>("Dersid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dersid"));

                    b.Property<string>("DersKodu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Dersad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("Dersid");

                    b.ToTable("tblDersler", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloNVC.Models.Ogrenci", b =>
                {
                    b.Property<int>("Ogrenciid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ogrenciid"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("Ogrenciid");

                    b.ToTable("tblOgrenciler", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloNVC.Models.OgrenciDersleri", b =>
                {
                    b.Property<int>("Ogrenciid")
                        .HasColumnType("int");

                    b.Property<int>("Dersid")
                        .HasColumnType("int");

                    b.HasKey("Ogrenciid", "Dersid");

                    b.HasIndex("Dersid");

                    b.ToTable("tblOgrneciDersleri", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloNVC.Models.OgrenciDersleri", b =>
                {
                    b.HasOne("Sube1.HelloNVC.Models.Ders", "ders")
                        .WithMany("OgrenciDersleri")
                        .HasForeignKey("Dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sube1.HelloNVC.Models.Ogrenci", "Ogrenci")
                        .WithMany("OgrenciDersleri")
                        .HasForeignKey("Ogrenciid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogrenci");

                    b.Navigation("ders");
                });

            modelBuilder.Entity("Sube1.HelloNVC.Models.Ders", b =>
                {
                    b.Navigation("OgrenciDersleri");
                });

            modelBuilder.Entity("Sube1.HelloNVC.Models.Ogrenci", b =>
                {
                    b.Navigation("OgrenciDersleri");
                });
#pragma warning restore 612, 618
        }
    }
}
