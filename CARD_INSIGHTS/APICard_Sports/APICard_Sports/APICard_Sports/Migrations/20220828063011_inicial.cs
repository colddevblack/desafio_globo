using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICard_Sports.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardcontentdb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardcontentdb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tagcontentdb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagcontentdb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardModelTagModel",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardModelTagModel", x => new { x.CardsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CardModelTagModel_Cardcontentdb_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cardcontentdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardModelTagModel_Tagcontentdb_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tagcontentdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardModelTagModel_TagsId",
                table: "CardModelTagModel",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardModelTagModel");

            migrationBuilder.DropTable(
                name: "Cardcontentdb");

            migrationBuilder.DropTable(
                name: "Tagcontentdb");
        }
    }
}
