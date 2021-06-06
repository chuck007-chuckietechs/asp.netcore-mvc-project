using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDPrototype.Data.NDMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ND");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientName = table.Column<string>(maxLength: 50, nullable: false),
                    ClientAddress = table.Column<string>(maxLength: 50, nullable: false),
                    ContactName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPhone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    PriceHour = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BidStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateComplete = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "ND",
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Items_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "ND",
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalSchema: "ND",
                        principalTable: "ItemTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabourId = table.Column<int>(nullable: false),
                    StaffFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    StaffLastName = table.Column<string>(maxLength: 50, nullable: true),
                    StaffPhone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Labours_LabourId",
                        column: x => x.LabourId,
                        principalSchema: "ND",
                        principalTable: "Labours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    ClosingDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    BidID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "ND",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "ND",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "ND",
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidItems",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BidId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    BidItemQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BidItems_Bids_BidId",
                        column: x => x.BidId,
                        principalSchema: "ND",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "ND",
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidStaffs",
                schema: "ND",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BidId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    BidStaffTotalHours = table.Column<int>(nullable: false),
                    BidStaffMarkup = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidStaffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BidStaffs_Bids_BidId",
                        column: x => x.BidId,
                        principalSchema: "ND",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidStaffs_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "ND",
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidItems_BidId",
                schema: "ND",
                table: "BidItems",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_BidItems_ItemId",
                schema: "ND",
                table: "BidItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidID",
                schema: "ND",
                table: "Bids",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "ND",
                table: "Bids",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_StatusId",
                schema: "ND",
                table: "Bids",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BidStaffs_BidId",
                schema: "ND",
                table: "BidStaffs",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_BidStaffs_StaffId",
                schema: "ND",
                table: "BidStaffs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemID",
                schema: "ND",
                table: "Items",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                schema: "ND",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                schema: "ND",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_LabourId",
                schema: "ND",
                table: "Staffs",
                column: "LabourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidItems",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "BidStaffs",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "ItemTypes",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Labours",
                schema: "ND");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "ND");
        }
    }
}
