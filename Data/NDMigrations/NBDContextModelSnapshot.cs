﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBDPrototype.Data;

namespace NBDPrototype.Data.NDMigrations
{
    [DbContext(typeof(NBDContext))]
    partial class NBDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ND")
                .HasAnnotation("ProductVersion", "3.1.13");

            modelBuilder.Entity("NBDPrototype.Models.Bid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int?>("BidID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ClosingDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BidID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("StatusId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("NBDPrototype.Models.BidItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BidId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BidItemQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BidId");

                    b.HasIndex("ItemId");

                    b.ToTable("BidItems");
                });

            modelBuilder.Entity("NBDPrototype.Models.BidStaff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BidId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BidStaffMarkup")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("BidStaffTotalHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BidId");

                    b.HasIndex("StaffId");

                    b.ToTable("BidStaffs");
                });

            modelBuilder.Entity("NBDPrototype.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<long>("ContactPhone")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("NBDPrototype.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NBDPrototype.Models.ItemType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("NBDPrototype.Models.Labour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<decimal>("PriceHour")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("ID");

                    b.ToTable("Labours");
                });

            modelBuilder.Entity("NBDPrototype.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateComplete")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NBDPrototype.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LabourId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StaffFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("StaffLastName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<long>("StaffPhone")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LabourId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("NBDPrototype.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BidStatus")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("NBDPrototype.Models.Bid", b =>
                {
                    b.HasOne("NBDPrototype.Models.Bid", null)
                        .WithMany("Bids")
                        .HasForeignKey("BidID");

                    b.HasOne("NBDPrototype.Models.Project", "Projects")
                        .WithMany("Bids")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBDPrototype.Models.Status", "Statuses")
                        .WithMany("Bids")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBDPrototype.Models.BidItem", b =>
                {
                    b.HasOne("NBDPrototype.Models.Bid", "Bid")
                        .WithMany("BidItems")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBDPrototype.Models.Item", "Item")
                        .WithMany("BidItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBDPrototype.Models.BidStaff", b =>
                {
                    b.HasOne("NBDPrototype.Models.Bid", "Bid")
                        .WithMany("BidStaffs")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBDPrototype.Models.Staff", "Staff")
                        .WithMany("BidStaffs")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBDPrototype.Models.Item", b =>
                {
                    b.HasOne("NBDPrototype.Models.Item", null)
                        .WithMany("Items")
                        .HasForeignKey("ItemID");

                    b.HasOne("NBDPrototype.Models.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBDPrototype.Models.Project", b =>
                {
                    b.HasOne("NBDPrototype.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBDPrototype.Models.Staff", b =>
                {
                    b.HasOne("NBDPrototype.Models.Labour", "Labour")
                        .WithMany("Staffs")
                        .HasForeignKey("LabourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}