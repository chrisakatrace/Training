using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Training.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Politics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoliticalParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Politics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pollsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    FK_Politics_Pollster = table.Column<int>(nullable: true),
                    PoliticsId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pollsters_Politics_FK_Politics_Pollster",
                        column: x => x.FK_Politics_Pollster,
                        principalTable: "Politics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pollsters_FK_Politics_Pollster",
                table: "Pollsters",
                column: "FK_Politics_Pollster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pollsters");

            migrationBuilder.DropTable(
                name: "Politics");
        }
    }
}
