using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id          = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    Title       = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date        = table.Column<DateTime>(nullable: false),
                    Time        = table.Column<TimeSpan>(nullable: false),
                    Location    = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedBy   = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Events", x => x.Id); });

            // Seed data
            migrationBuilder.InsertData("Events",
                new[] { "Id","Title","Description","Date","Time","Location","CreatedBy" },
                new object[] { 1, "Community Clean-Up Day",
                    "Join us to clean up Riverside Park. Gloves and bags provided.",
                    new DateTime(2025,6,14), new TimeSpan(9,0,0),
                    "Riverside Park, Main Entrance", "admin" });

            migrationBuilder.InsertData("Events",
                new[] { "Id","Title","Description","Date","Time","Location","CreatedBy" },
                new object[] { 2, "Summer BBQ & Fundraiser",
                    "Annual neighbourhood BBQ. All proceeds go to the local food bank.",
                    new DateTime(2025,7,4), new TimeSpan(13,0,0),
                    "Community Centre Grounds", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Events");
        }
    }
}
