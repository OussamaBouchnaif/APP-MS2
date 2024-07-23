using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class dossierMedical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DossierMedical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StructureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformedService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    StructureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotifAcoompagnement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentationEffectueé = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Commentaires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureBenificier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    benificierId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierMedical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierMedical_Personnes_benificierId",
                        column: x => x.benificierId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierMedical_benificierId",
                table: "DossierMedical",
                column: "benificierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DossierMedical");
        }
    }
}
