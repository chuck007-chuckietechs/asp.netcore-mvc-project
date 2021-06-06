using Microsoft.EntityFrameworkCore;
using NBDPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Data
{
    public class NBDContext:DbContext
    {
        public NBDContext(DbContextOptions<NBDContext> options)
         : base(options)
        {
        }

        public DbSet<Client>Clients { get; set; }



        public DbSet<Bid> Bids { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Labour> Labours { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<BidItem> BidItems { get; set; }

        public DbSet<BidStaff> BidStaffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ND");

            modelBuilder.Entity<Project>()
                .HasOne(e => e.Client)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.ClientID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Projects)
                .WithOne(c => c.Client)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<BidItem>().Ignore(c => c.TotalItemCosts);
            //modelBuilder.Entity<BidStaff>().Ignore(c => c.BidStaffTotalHours);
        }

    }
    
}
