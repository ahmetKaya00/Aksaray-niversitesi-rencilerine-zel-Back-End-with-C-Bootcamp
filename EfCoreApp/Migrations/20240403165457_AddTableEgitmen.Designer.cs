﻿// <auto-generated />
using System;
using EfCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240403165457_AddTableEgitmen")]
    partial class AddTableEgitmen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("EfCoreApp.Data.Bootcamp", b =>
                {
                    b.Property<int>("BootcampId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EgitmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BootcampId");

                    b.HasIndex("EgitmenId");

                    b.ToTable("Bootcamps");
                });

            modelBuilder.Entity("EfCoreApp.Data.BootcampKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BootcampId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("BootcampId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("Kayitlar");
                });

            modelBuilder.Entity("EfCoreApp.Data.Egitmen", b =>
                {
                    b.Property<int>("EgitmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("EgitmenId");

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("EfCoreApp.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("EfCoreApp.Data.Bootcamp", b =>
                {
                    b.HasOne("EfCoreApp.Data.Egitmen", "Egitmen")
                        .WithMany("Bootcamps")
                        .HasForeignKey("EgitmenId");

                    b.Navigation("Egitmen");
                });

            modelBuilder.Entity("EfCoreApp.Data.BootcampKayit", b =>
                {
                    b.HasOne("EfCoreApp.Data.Bootcamp", "Bootcamp")
                        .WithMany("BootcampKayit")
                        .HasForeignKey("BootcampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreApp.Data.Ogrenci", "Ogrenci")
                        .WithMany("BootcampKayit")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bootcamp");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("EfCoreApp.Data.Bootcamp", b =>
                {
                    b.Navigation("BootcampKayit");
                });

            modelBuilder.Entity("EfCoreApp.Data.Egitmen", b =>
                {
                    b.Navigation("Bootcamps");
                });

            modelBuilder.Entity("EfCoreApp.Data.Ogrenci", b =>
                {
                    b.Navigation("BootcampKayit");
                });
#pragma warning restore 612, 618
        }
    }
}
