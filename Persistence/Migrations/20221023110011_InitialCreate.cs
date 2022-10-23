using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Passsword = table.Column<string>(type: "nvarchar(MAX)", maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(MAX)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(MAX)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(MAX)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
