using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class AddVeilleContextuelles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeilleContextuelle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEvenement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeEvenement = table.Column<int>(type: "int", nullable: false),
                    DetailsEvenement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SourceInformation = table.Column<int>(type: "int", nullable: false),
                    AutresSourceInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NombreMigrants = table.Column<int>(type: "int", nullable: false),
                    TypeMigrants = table.Column<int>(type: "int", nullable: false),
                    Nationalites = table.Column<int>(type: "int", nullable: false),
                    AutresNationalites = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    NombreHommes = table.Column<int>(type: "int", nullable: true),
                    NombreFemmes = table.Column<int>(type: "int", nullable: true),
                    NombreMENA = table.Column<int>(type: "int", nullable: true),
                    NombreEnfants = table.Column<int>(type: "int", nullable: true),
                    NombreSoudan = table.Column<int>(type: "int", nullable: true),
                    NombreSudsoudan = table.Column<int>(type: "int", nullable: true),
                    NombreGuinee = table.Column<int>(type: "int", nullable: true),
                    NombreCameroun = table.Column<int>(type: "int", nullable: true),
                    NombreCotedIvoire = table.Column<int>(type: "int", nullable: true),
                    NombreMali = table.Column<int>(type: "int", nullable: true),
                    NombreNigeria = table.Column<int>(type: "int", nullable: true),
                    NombreSenegal = table.Column<int>(type: "int", nullable: true),
                    NombreRDC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeilleContextuelle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeilleContextuelle_Personnes_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeilleContextuelle_UtilisateurId",
                table: "VeilleContextuelle",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeilleContextuelle");
        }
    }
}
