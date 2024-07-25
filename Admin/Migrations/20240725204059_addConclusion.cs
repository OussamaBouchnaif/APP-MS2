using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class addConclusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuiviSociale_DossierSociale_DossierSocialeId",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "Accompagnement",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiNouvelle",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiSocioprofessionnelNouvelle",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiSocioprofessionnelSuivi",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiSuivi",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DemandeInfo",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DiscussionPlanDeSuite",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "HebergementNouvelle",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "HebergementSuivi",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "KitsAlimentationNouvelle",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "KitsAlimentationSuivi",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "PMNouvelle",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "PMSuivi",
                table: "SuiviSociale");

            migrationBuilder.RenameColumn(
                name: "DistributionDeKit",
                table: "SuiviSociale",
                newName: "DistributiondeKit");

            migrationBuilder.RenameColumn(
                name: "Autre2",
                table: "SuiviSociale",
                newName: "autre2");

            migrationBuilder.RenameColumn(
                name: "Informations",
                table: "SuiviSociale",
                newName: "kitsAlimentaionEtHyfiene");

            migrationBuilder.RenameColumn(
                name: "DistributionDeKitDesc",
                table: "SuiviSociale",
                newName: "Autre3");

            migrationBuilder.RenameColumn(
                name: "DateEntreeHebergement",
                table: "SuiviSociale",
                newName: "DateEntreeHebergementUrgence");

            migrationBuilder.AlterColumn<bool>(
                name: "ReferencementIntern",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReferencementExterne",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DossierSocialeId",
                table: "SuiviSociale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "DistributiondeKit",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActeDeNaissance",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AnamneseEtDiscusionPlanDesuite",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiAdminstrative",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiSocialProfessionnel",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BenificierId",
                table: "SuiviSociale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DelivranceInformation",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DemandeAsile",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DemandeInformation",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DemandeRetourVolontaire",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hebergement",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PriseEnChargeMedical",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "emploi",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formation",
                table: "SuiviSociale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Conclusion",
                table: "DossierPersonnel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuiviSociale_DossierSociale_DossierSocialeId",
                table: "SuiviSociale",
                column: "DossierSocialeId",
                principalTable: "DossierSociale",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuiviSociale_DossierSociale_DossierSocialeId",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ActeDeNaissance",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "AnamneseEtDiscusionPlanDesuite",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiAdminstrative",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "ApuiSocialProfessionnel",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "BenificierId",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DelivranceInformation",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DemandeAsile",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DemandeInformation",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "DemandeRetourVolontaire",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "Hebergement",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "PriseEnChargeMedical",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "emploi",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "formation",
                table: "SuiviSociale");

            migrationBuilder.DropColumn(
                name: "Conclusion",
                table: "DossierPersonnel");

            migrationBuilder.RenameColumn(
                name: "autre2",
                table: "SuiviSociale",
                newName: "Autre2");

            migrationBuilder.RenameColumn(
                name: "DistributiondeKit",
                table: "SuiviSociale",
                newName: "DistributionDeKit");

            migrationBuilder.RenameColumn(
                name: "kitsAlimentaionEtHyfiene",
                table: "SuiviSociale",
                newName: "Informations");

            migrationBuilder.RenameColumn(
                name: "DateEntreeHebergementUrgence",
                table: "SuiviSociale",
                newName: "DateEntreeHebergement");

            migrationBuilder.RenameColumn(
                name: "Autre3",
                table: "SuiviSociale",
                newName: "DistributionDeKitDesc");

            migrationBuilder.AlterColumn<bool>(
                name: "ReferencementIntern",
                table: "SuiviSociale",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ReferencementExterne",
                table: "SuiviSociale",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "DossierSocialeId",
                table: "SuiviSociale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DistributionDeKit",
                table: "SuiviSociale",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Accompagnement",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiNouvelle",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiSocioprofessionnelNouvelle",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiSocioprofessionnelSuivi",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApuiSuivi",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DemandeInfo",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DiscussionPlanDeSuite",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HebergementNouvelle",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HebergementSuivi",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KitsAlimentationNouvelle",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KitsAlimentationSuivi",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PMNouvelle",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PMSuivi",
                table: "SuiviSociale",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuiviSociale_DossierSociale_DossierSocialeId",
                table: "SuiviSociale",
                column: "DossierSocialeId",
                principalTable: "DossierSociale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
