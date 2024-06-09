﻿// <auto-generated />
using System;
using APBD_przykladowykolos2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBD_przykladowykolos2.Migrations
{
    [DbContext(typeof(BoatReservationDbContext))]
    partial class BoatReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.BoatStandard", b =>
                {
                    b.Property<int>("IdBoatStandard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBoatStandard"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdBoatStandard")
                        .HasName("BoatStandard_pk");

                    b.ToTable("BoatStandard", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdClientCategory")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClient")
                        .HasName("Client_pk");

                    b.HasIndex("IdClientCategory");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.ClientCategory", b =>
                {
                    b.Property<int>("IdClientCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientCategory"));

                    b.Property<int>("DiscountPerc")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClientCategory")
                        .HasName("ClientCategory_pk");

                    b.ToTable("ClientCategory", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<string>("CancelReason")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("bit");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("NumOfBoats")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("IdReservation")
                        .HasName("Reservation_pk");

                    b.HasIndex("IdBoatStandard");

                    b.HasIndex("IdClient");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Sailboat", b =>
                {
                    b.Property<int>("IdSailboat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSailboat"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("IdSailboat")
                        .HasName("Sailboat_pk");

                    b.HasIndex("IdBoatStandard");

                    b.ToTable("Sailboat", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Sailboat_Reservation", b =>
                {
                    b.Property<int>("IdSailboat")
                        .HasColumnType("int");

                    b.Property<int>("IdReservation")
                        .HasColumnType("int");

                    b.HasKey("IdSailboat", "IdReservation");

                    b.HasIndex("IdReservation");

                    b.ToTable("Sailboat_Reservation", (string)null);
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Client", b =>
                {
                    b.HasOne("APBD_przykladowykolos2.Entities.ClientCategory", "ClientCategory")
                        .WithMany("Clients")
                        .HasForeignKey("IdClientCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientCategory");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Reservation", b =>
                {
                    b.HasOne("APBD_przykladowykolos2.Entities.BoatStandard", "BoatStandard")
                        .WithMany("Reservations")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_przykladowykolos2.Entities.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatStandard");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Sailboat", b =>
                {
                    b.HasOne("APBD_przykladowykolos2.Entities.BoatStandard", "BoatStandard")
                        .WithMany("Sailboats")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatStandard");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Sailboat_Reservation", b =>
                {
                    b.HasOne("APBD_przykladowykolos2.Entities.Reservation", "Reservation")
                        .WithMany("Sailboat_Reservations")
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_przykladowykolos2.Entities.Sailboat", "Sailboat")
                        .WithMany("Sailboat_Reservations")
                        .HasForeignKey("IdSailboat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Sailboat");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.BoatStandard", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Sailboats");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.ClientCategory", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Reservation", b =>
                {
                    b.Navigation("Sailboat_Reservations");
                });

            modelBuilder.Entity("APBD_przykladowykolos2.Entities.Sailboat", b =>
                {
                    b.Navigation("Sailboat_Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
