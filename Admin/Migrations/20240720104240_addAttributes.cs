using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class addAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutreHabit",
                table: "SituationSocioEconomique",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutreSource",
                table: "SituationSocioEconomique",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AucunPiece",
                table: "SituationAdministrative",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AucunTite",
                table: "SituationAdministrative",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Autre",
                table: "SituationAdministrative",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutreMotif",
                table: "ParcoursMigratoire",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutreHabit",
                table: "SituationSocioEconomique");

            migrationBuilder.DropColumn(
                name: "AutreSource",
                table: "SituationSocioEconomique");

            migrationBuilder.DropColumn(
                name: "AucunPiece",
                table: "SituationAdministrative");

            migrationBuilder.DropColumn(
                name: "AucunTite",
                table: "SituationAdministrative");

            migrationBuilder.DropColumn(
                name: "Autre",
                table: "SituationAdministrative");

            migrationBuilder.DropColumn(
                name: "AutreMotif",
                table: "ParcoursMigratoire");
        }
    }
}
