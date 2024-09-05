using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmKategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmKategoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyuncuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biyografi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SonYayinTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzlenmeSayisi = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    FilmDetayID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Filmler_FilmKategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "FilmKategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmDetaylar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetaylar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilmDetaylar_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OyuncuFilmler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalismaGunu = table.Column<int>(type: "int", nullable: false),
                    OyuncuID = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuFilmler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OyuncuFilmler_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OyuncuFilmler_Oyuncular_OyuncuID",
                        column: x => x.OyuncuID,
                        principalTable: "Oyuncular",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetaylar_FilmID",
                table: "FilmDetaylar",
                column: "FilmID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_KategoriID",
                table: "Filmler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuFilmler_FilmID",
                table: "OyuncuFilmler",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuFilmler_OyuncuID",
                table: "OyuncuFilmler",
                column: "OyuncuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmDetaylar");

            migrationBuilder.DropTable(
                name: "OyuncuFilmler");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Oyuncular");

            migrationBuilder.DropTable(
                name: "FilmKategoriler");
        }
    }
}
