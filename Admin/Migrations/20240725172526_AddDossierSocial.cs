using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class AddDossierSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DossierSociale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandeInformation = table.Column<bool>(type: "bit", nullable: true),
                    PriseEnChargeMedical = table.Column<bool>(type: "bit", nullable: true),
                    Hebergement = table.Column<bool>(type: "bit", nullable: true),
                    ApuiAdminstrative = table.Column<bool>(type: "bit", nullable: true),
                    ActeDeNaissance = table.Column<bool>(type: "bit", nullable: true),
                    DemandeAsile = table.Column<bool>(type: "bit", nullable: true),
                    DemandeRetourVolontaire = table.Column<bool>(type: "bit", nullable: true),
                    autre1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kitsAlimentaionEtHyfiene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApuiSocialProfessionnel = table.Column<bool>(type: "bit", nullable: true),
                    formation = table.Column<bool>(type: "bit", nullable: true),
                    emploi = table.Column<bool>(type: "bit", nullable: true),
                    autre2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelivranceInformation = table.Column<bool>(type: "bit", nullable: true),
                    AnamneseEtDiscusionPlanDesuite = table.Column<bool>(type: "bit", nullable: true),
                    DateEntreeHebergementUrgence = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistributiondeKit = table.Column<bool>(type: "bit", nullable: true),
                    AccompagnementPhysique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferencementExterne = table.Column<bool>(type: "bit", nullable: true),
                    ReferencementIntern = table.Column<bool>(type: "bit", nullable: true),
                    Extenrene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autre3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsEtResultats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenificierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierSociale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierSociale_Personnes_BenificierId",
                        column: x => x.BenificierId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuiviSociale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandeInfo = table.Column<bool>(type: "bit", nullable: true),
                    PMSuivi = table.Column<bool>(type: "bit", nullable: true),
                    PMNouvelle = table.Column<bool>(type: "bit", nullable: true),
                    HebergementSuivi = table.Column<bool>(type: "bit", nullable: true),
                    HebergementNouvelle = table.Column<bool>(type: "bit", nullable: true),
                    ApuiSuivi = table.Column<bool>(type: "bit", nullable: true),
                    ApuiNouvelle = table.Column<bool>(type: "bit", nullable: true),
                    KitsAlimentationSuivi = table.Column<bool>(type: "bit", nullable: true),
                    KitsAlimentationNouvelle = table.Column<bool>(type: "bit", nullable: true),
                    ApuiSocioprofessionnelSuivi = table.Column<bool>(type: "bit", nullable: true),
                    ApuiSocioprofessionnelNouvelle = table.Column<bool>(type: "bit", nullable: true),
                    autre1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscussionPlanDeSuite = table.Column<bool>(type: "bit", nullable: true),
                    DateEntreeHebergement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistributionDeKit = table.Column<bool>(type: "bit", nullable: true),
                    DistributionDeKitDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accompagnement = table.Column<bool>(type: "bit", nullable: true),
                    AccompagnementPhysique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferencementExterne = table.Column<bool>(type: "bit", nullable: true),
                    ReferencementIntern = table.Column<bool>(type: "bit", nullable: true),
                    Extenrene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autre2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsEtResultats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DossierSocialeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviSociale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuiviSociale_DossierSociale_DossierSocialeId",
                        column: x => x.DossierSocialeId,
                        principalTable: "DossierSociale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierSociale_BenificierId",
                table: "DossierSociale",
                column: "BenificierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuiviSociale_DossierSocialeId",
                table: "SuiviSociale",
                column: "DossierSocialeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuiviSociale");

            migrationBuilder.DropTable(
                name: "DossierSociale");
        }
    }
}
