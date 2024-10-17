using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JegyzetekWebApp.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_758 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kartyak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartyak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teendok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tartalom = table.Column<string>(type: "TEXT", nullable: true),
                    Letrehozve = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modositva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Kesz = table.Column<bool>(type: "INTEGER", nullable: false),
                    KartyaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teendok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teendok_Kartyak_KartyaId",
                        column: x => x.KartyaId,
                        principalTable: "Kartyak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teendok_KartyaId",
                table: "Teendok",
                column: "KartyaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teendok");

            migrationBuilder.DropTable(
                name: "Kartyak");
        }
    }
}
