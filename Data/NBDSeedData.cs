using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NBDPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Data
{
    public static class NBDSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NBDContext(
                serviceProvider.GetRequiredService<DbContextOptions<NBDContext>>()))
            {
                // Look for any Projects.  Since we can't have projectss without Clients.
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                     new Client
                     {
                         ClientName = "London Sq.Mall",
                         ClientAddress = "1263 Mall Drive Scotts Valley, CA 95060",
                         ContactName = "Amy Benson, Mgr.",
                         ContactPhone = 4088345603
                     },

                     new Client
                     {
                         ClientName = "Zoom Technologies",
                         ClientAddress = "3451 Calvary Drive, CA 85460",
                         ContactName = "Paul Simon , Mgr.",
                         ContactPhone = 9063453332
                     },

                     new Client
                     {
                         ClientName = "Ambac Financial Group",
                         ClientAddress = "396 Shirley Court Kirkville, NY 13082",
                         ContactName = "James Brown , Mgr.",
                         ContactPhone = 7783459352
                     },

                     new Client
                     {
                        ClientName = "ABM Industries",
                        ClientAddress = "414 Galvin Avenue Rock City Falls, NY 12863",
                        ContactName = "Annika M Ramos",
                        ContactPhone = 4357890974
                    },

                    new Client
                    {
                        ClientName = "Standard Chartered USA",
                        ClientAddress = "85 East Tower Rd. New York, NY 10184",
                        ContactName = "Billy C Jean",
                        ContactPhone = 7856780834
                    }

                    );
                        context.SaveChanges();

                    }

                if (!context.ItemTypes.Any())
                {
                    context.ItemTypes.AddRange(
                     new ItemType
                     {
                         Type = "Plant"
                     },

                     new ItemType
                     {
                         Type = "Pottery"
                     },

                     new ItemType
                     {
                         Type = "Material"
                     },

                    new ItemType
                    {
                        Type = "Tool"
                    }

                    );
                    context.SaveChanges();

                }

                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(
                     new Status
                     {
                         BidStatus = "In Progress"
                     },

                     new Status
                     {
                         BidStatus = "Waiting for Manager Approval"
                     },

                     new Status
                     {
                         BidStatus = "Waiting for Client Approval"
                     },

                    new Status
                    {
                        BidStatus = "Rejected"
                    },
                    new Status
                    {
                        BidStatus = "Finalized"
                    }

                    );
                    context.SaveChanges();

                }

                if (!context.Labours.Any())
                {
                    context.Labours.AddRange(
                     new Labour
                     {
                         Description = "Designer",
                         PriceHour = 145.00m
                     },
                     new Labour
                     {
                         Description = "General Manager",
                         PriceHour = 160.00m
                     },
                     new Labour
                     {
                         Description = "Administrative Assistant",
                         PriceHour = 120.00m
                     },
                     new Labour
                     {
                         Description = "Group Manager",
                         PriceHour = 145.00m
                     },
                     new Labour
                     {
                         Description = "Production Worker",
                         PriceHour = 84.00m
                     },
                     new Labour
                     {
                         Description = "Sales Associate",
                         PriceHour = 85.00m
                     }

                    );
                    context.SaveChanges();

                }

                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                    new Project
                    {
                        Name = "Niagara Maids",
                        Location = "Saint Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "London Sq.Mall").ID,
                        DateStart = DateTime.Parse("2021-02-02"),
                        DateComplete = DateTime.Parse("2021-08-15")

                    },

                    new Project
                    {
                        Name = "Old Dominion Coin & Currency",
                        Location = "St.Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "London Sq.Mall").ID,
                        DateStart = DateTime.Parse("2021-08-09"),
                        DateComplete = DateTime.Parse("2021-09-05")

                    },
                    new Project
                    {
                        Name = "Aura Landscaping",
                        Location = "St Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Zoom Technologies").ID,
                        DateStart = DateTime.Parse("2021-01-22"),
                        DateComplete = DateTime.Parse("2021-07-26")

                    },

                    new Project
                    {
                        Name = "Security Surveillance Group",
                        Location = "Virgil",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Zoom Technologies").ID,
                        DateStart = DateTime.Parse("2021-12-02"),
                        DateComplete = DateTime.Parse("2022-01-05")

                    },

                    new Project
                    {
                        Name = "The Pelham Street Grille",
                        Location = "Pelham",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Ambac Financial Group").ID,
                        
                        DateStart = DateTime.Parse("2021-12-22"),
                        DateComplete = DateTime.Parse("2022-02-01")

                    },

                    new Project
                    {
                        Name = "Old Dominion Coin & Currency",
                        Location = "St.Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Ambac Financial Group").ID,
                        
                        DateStart = DateTime.Parse("2021-09-29"),
                        DateComplete = DateTime.Parse("2021-10-05")

                    },
                    new Project
                    {
                        Name = "Pine Street Dental",
                        Location = "Thorold",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "ABM Industries").ID,
                      
                        DateStart = DateTime.Parse("2021-01-17"),
                        DateComplete = DateTime.Parse("2021-06-05")

                    },

                    new Project
                    {
                        Name = "Old Dominion Coin & Currency",
                        Location = "St.Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "ABM Industries").ID,
                       
                        DateStart = DateTime.Parse("2021-04-22"),
                        DateComplete = DateTime.Parse("2021-10-18")

                    },
                    new Project
                    {
                        Name = "Ultimate Mum Pillows",
                        Location = "St.Catharines",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Standard Chartered USA").ID,
                        
                        DateStart = DateTime.Parse("2021-10-11"),
                        DateComplete = DateTime.Parse("2021-12-05")

                    },

                    new Project
                    {
                        Name = "Alpha Boss Computer Services",
                        Location = "Welland",
                        ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Standard Chartered USA").ID,
                       
                        DateStart = DateTime.Parse("2021-09-12"),
                        DateComplete = DateTime.Parse("2021-09-20")

                    });
                        context.SaveChanges();
                    }

                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Group Manager").ID,
                        StaffFirstName = "Cheryl",
                        StaffLastName = "Poy",
                        StaffPhone = 2892892889
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Group Manager").ID,
                        StaffFirstName = "Sue",
                        StaffLastName = "Kauffman",
                        StaffPhone = 9052310090
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Designer").ID,
                        StaffFirstName = "Keri",
                        StaffLastName = "Yamaguchi",
                        StaffPhone = 2852192849
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Designer").ID,
                        StaffFirstName = "Tamara",
                        StaffLastName = "Bakken",
                        StaffPhone = 2891842385
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "General Manager").ID,
                        StaffFirstName = "Stan",
                        StaffLastName = "Fenton",
                        StaffPhone = 2892892889
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Administrative Assistant").ID,
                        StaffFirstName = "Connie",
                        StaffLastName = "Nguyen",
                        StaffPhone = 2891692349
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Sales Associate").ID,
                        StaffFirstName = "Bob",
                        StaffLastName = "Reinhardt",
                        StaffPhone = 2891894582
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Production Worker").ID,
                        StaffFirstName = "Monica",
                        StaffLastName = "Goce",
                        StaffPhone = 2892896539
                    },
                    new Staff
                    {
                        LabourId = context.Labours.FirstOrDefault(d => d.Description == "Production Worker").ID,
                        StaffFirstName = "Bert",
                        StaffLastName = "Swenson",
                        StaffPhone = 2891892119
                    });
                    context.SaveChanges();
                }

                if (!context.Items.Any())
                {
                    context.Items.AddRange(
                    new Item
                    {
                        Code = "lacco",
                        ItemTypeId = context.ItemTypes.FirstOrDefault(d => d.Type == "Plant").ID,
                        Description = "Lacco Australasica",
                        Size = "15gal",
                        Price = 450.00m
                    },
                    new Item
                    {
                        Code = "TCP50",
                        ItemTypeId = context.ItemTypes.FirstOrDefault(d => d.Type == "Pottery").ID,
                        Description = "T/C Pot",
                        Size = "50gal",
                        Price = 53.95m
                    },
                    new Item
                    {
                        Code = "CBRK5",
                        ItemTypeId = context.ItemTypes.FirstOrDefault(d => d.Type == "Material").ID,
                        Description = "Decorative Cedar Bark",
                        Size = "Bag(5 cu ft)",
                        Price = 7.50m
                    },
                    new Item
                    {
                        Code = "WRC21",
                        ItemTypeId = context.ItemTypes.FirstOrDefault(d => d.Type == "Tool").ID,
                        Description = "Wrench",
                        Size = "6in",
                        Price = 21.99m
                    });
                    context.SaveChanges();
                }

                if (!context.Bids.Any())
                {
                    context.Bids.AddRange(
                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Ultimate Mum Pillows").ID,
                        Date = DateTime.Parse("2021-01-15"),
                        StartDate = DateTime.Parse("2021-01-21"),
                        ClosingDate = DateTime.Parse("2021-05-02"),
                        Amount = 10200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Rejected").ID,
                        IsApproved = false
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "The Pelham Street Grille").ID,
                        Date = DateTime.Parse("2021-01-15"),
                        StartDate = DateTime.Parse("2021-06-21"),
                        ClosingDate = DateTime.Parse("2021-07-02"),
                        Amount = 1200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Waiting for Client Approval").ID,
                        IsApproved = false
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "The Pelham Street Grille").ID,
                        Date = DateTime.Parse("2021-01-20"),
                        StartDate = DateTime.Parse("2021-06-21"),
                        ClosingDate = DateTime.Parse("2021-07-02"),
                        Amount = 1000.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Finalized").ID,
                        IsApproved = true
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Pine Street Dental").ID,
                        Date = DateTime.Parse("2021-01-15"),
                        StartDate = DateTime.Parse("2021-11-12"),
                        ClosingDate = DateTime.Parse("2021-12-02"),
                        Amount = 1102.00m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Waiting for Manager Approval").ID,
                        IsApproved = false
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Niagara Maids").ID,
                        Date = DateTime.Parse("2021-05-26"),
                        StartDate = DateTime.Parse("2021-06-21"),
                        ClosingDate = DateTime.Parse("2021-07-12"),
                        Amount = 17200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Rejected").ID,
                        IsApproved = false
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Niagara Maids").ID,
                        Date = DateTime.Parse("2021-05-26"),
                        StartDate = DateTime.Parse("2021-06-21"),
                        ClosingDate = DateTime.Parse("2021-07-21"),
                        Amount = 14200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Finalized").ID,
                        IsApproved = true
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Aura Landscaping").ID,
                        Date = DateTime.Parse("2021-07-01"),
                        StartDate = DateTime.Parse("2021-08-21"),
                        ClosingDate = DateTime.Parse("2021-09-20"),
                        Amount = 12200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Rejected").ID,
                        IsApproved = false
                    },

                    new Bid
                    {
                        ProjectID = context.Projects.FirstOrDefault(c => c.Name == "Aura Landscaping").ID,
                        Date = DateTime.Parse("2021-07-15"),
                        StartDate = DateTime.Parse("2021-08-21"),
                        ClosingDate = DateTime.Parse("2021-09-02"),
                        Amount = 110200.99m,
                        StatusId = context.Statuses.FirstOrDefault(a => a.BidStatus == "Waiting for Client Approval").ID,
                        IsApproved = false
                    }
                    );
                    context.SaveChanges();
                }

                if (!context.BidItems.Any())
                {
                    context.BidItems.AddRange(
                     new BidItem
                     {
                         BidId = 1,
                         ItemId = 1,
                         BidItemQuantity = 5
                     }
                    );
                    context.SaveChanges();

                }
                
                if (!context.BidStaffs.Any())
                {
                    context.BidStaffs.AddRange(
                     new BidStaff
                     {
                         BidId = 1,
                         StaffId = 1,
                         BidStaffTotalHours = 41,
                         BidStaffMarkup = 210.11m
                     }
                    );
                    context.SaveChanges();

                }
            }
        }
    }
}
