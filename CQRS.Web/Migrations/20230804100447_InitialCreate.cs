﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "LastName", "Name" },
                values: new object[] { 1, 22, "Karaman", "Eray" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "LastName", "Name" },
                values: new object[] { 2, 12, "Karaman", "Nida" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "LastName", "Name" },
                values: new object[] { 3, 52, "Cafer", "Ali" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
