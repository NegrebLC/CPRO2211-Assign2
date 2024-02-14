using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CPRO2211_Assign2.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friends" },
                    { 3, "Work" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "Phone" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5605), "bergcu2001@gmail.com", "Bergen", "Cunningham", "Red Deer Polytechnic", "587-876-7305" },
                    { 2, 2, new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5608), "jeannellecousineau2001@gmail.com", "Jeannelle", "Cousineau", "Royal LePage", "403-307-6227" },
                    { 3, 3, new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5611), "steve.smith@gmail.com", "Steve", "Smith", null, "555-555-5555" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
