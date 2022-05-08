using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Password);
                });

            migrationBuilder.CreateTable(
                name: "SubForums",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnedByPassword = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubForums", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_SubForums_User_OwnedByPassword",
                        column: x => x.OwnedByPassword,
                        principalTable: "User",
                        principalColumn: "Password");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubForums_OwnedByPassword",
                table: "SubForums",
                column: "OwnedByPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubForums");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
