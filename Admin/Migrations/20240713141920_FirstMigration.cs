using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonneType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeleUrgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaysOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDetection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codeUnique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DossierPersonnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LieuxDintervention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenificierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierPersonnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierPersonnel_Personnes_BenificierId",
                        column: x => x.BenificierId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcoursMigratoire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotifDepart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneeEntree = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VilleEntree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<int>(type: "int", nullable: true),
                    DureeEntree = table.Column<int>(type: "int", nullable: true),
                    NouvelleArrivante = table.Column<bool>(type: "bit", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcoursMigratoire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcoursMigratoire_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SituationAdministrative",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarteMarocaine = table.Column<bool>(type: "bit", nullable: true),
                    ValidationPassport = table.Column<bool>(type: "bit", nullable: true),
                    CarteConsulaire = table.Column<bool>(type: "bit", nullable: true),
                    ActeDeNaissance = table.Column<bool>(type: "bit", nullable: true),
                    CarteSejourValid = table.Column<bool>(type: "bit", nullable: true),
                    StatusDeRefugie = table.Column<bool>(type: "bit", nullable: true),
                    RecepisseDedemande = table.Column<bool>(type: "bit", nullable: true),
                    Visa = table.Column<bool>(type: "bit", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationAdministrative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituationAdministrative_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SituationFamiliale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mineur = table.Column<bool>(type: "bit", nullable: true),
                    Accompagne = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituationMatrimoniale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfantAcharge = table.Column<bool>(type: "bit", nullable: true),
                    Nombre = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationFamiliale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituationFamiliale_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SituationPsychologique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enceinte = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaladieChronique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituationDeDetresse = table.Column<bool>(type: "bit", nullable: true),
                    MaladieMentale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Handicap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationPsychologique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituationPsychologique_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SituationSocioEconomique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NiveauEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormationPersonnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationSocioEconomique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituationSocioEconomique_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SituationViolence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Victim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicateur = table.Column<bool>(type: "bit", nullable: true),
                    VictimArretation = table.Column<bool>(type: "bit", nullable: true),
                    Victimrefoulement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DossierPersonnelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationViolence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituationViolence_DossierPersonnel_DossierPersonnelId",
                        column: x => x.DossierPersonnelId,
                        principalTable: "DossierPersonnel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierPersonnel_BenificierId",
                table: "DossierPersonnel",
                column: "BenificierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcoursMigratoire_DossierPersonnelId",
                table: "ParcoursMigratoire",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SituationAdministrative_DossierPersonnelId",
                table: "SituationAdministrative",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SituationFamiliale_DossierPersonnelId",
                table: "SituationFamiliale",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SituationPsychologique_DossierPersonnelId",
                table: "SituationPsychologique",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SituationSocioEconomique_DossierPersonnelId",
                table: "SituationSocioEconomique",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SituationViolence_DossierPersonnelId",
                table: "SituationViolence",
                column: "DossierPersonnelId",
                unique: true,
                filter: "[DossierPersonnelId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParcoursMigratoire");

            migrationBuilder.DropTable(
                name: "SituationAdministrative");

            migrationBuilder.DropTable(
                name: "SituationFamiliale");

            migrationBuilder.DropTable(
                name: "SituationPsychologique");

            migrationBuilder.DropTable(
                name: "SituationSocioEconomique");

            migrationBuilder.DropTable(
                name: "SituationViolence");

            migrationBuilder.DropTable(
                name: "DossierPersonnel");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
