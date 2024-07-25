using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class AddTableAvis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierMedical_Personnes_benificierId",
                table: "DossierMedical");

            migrationBuilder.RenameColumn(
                name: "benificierId",
                table: "DossierMedical",
                newName: "BenificierId");

            migrationBuilder.RenameIndex(
                name: "IX_DossierMedical_benificierId",
                table: "DossierMedical",
                newName: "IX_DossierMedical_BenificierId");

            migrationBuilder.AlterColumn<string>(
                name: "codeUnique",
                table: "Personnes",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Avis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenue = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    BenificierId = table.Column<int>(type: "int", nullable: false),
                    BenifierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avis_Personnes_BenificierId",
                        column: x => x.BenificierId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_codeUnique",
                table: "Personnes",
                column: "codeUnique",
                unique: true,
                filter: "[codeUnique] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Avis_BenificierId",
                table: "Avis",
                column: "BenificierId");

            migrationBuilder.AddForeignKey(
                name: "FK_DossierMedical_Personnes_BenificierId",
                table: "DossierMedical",
                column: "BenificierId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierMedical_Personnes_BenificierId",
                table: "DossierMedical");

            migrationBuilder.DropTable(
                name: "Avis");

            migrationBuilder.DropIndex(
                name: "IX_Personnes_codeUnique",
                table: "Personnes");

            migrationBuilder.RenameColumn(
                name: "BenificierId",
                table: "DossierMedical",
                newName: "benificierId");

            migrationBuilder.RenameIndex(
                name: "IX_DossierMedical_BenificierId",
                table: "DossierMedical",
                newName: "IX_DossierMedical_benificierId");

            migrationBuilder.AlterColumn<string>(
                name: "codeUnique",
                table: "Personnes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierMedical_Personnes_benificierId",
                table: "DossierMedical",
                column: "benificierId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}