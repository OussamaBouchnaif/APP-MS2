﻿// <auto-generated />
using System;
using MS2Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admin.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240725144033_AddTableAvis")]
    partial class AddTableAvis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Admin.Models.Avis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BenificierId")
                        .HasColumnType("int");

                    b.Property<int>("BenifierId")
                        .HasColumnType("int");

                    b.Property<string>("Contenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BenificierId");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("Admin.Models.DossierMedical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BenificierId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaires")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("MotifAcoompagnement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerformedService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresentationEffectueé")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Responsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignatureBenificier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StructureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StructureType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenificierId");

                    b.ToTable("DossierMedical");
                });

            modelBuilder.Entity("Admin.Models.VeilleContextuelle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AutresNationalites")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AutresSourceInformation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateEvenement")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailsEvenement")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Nationalites")
                        .HasColumnType("int");

                    b.Property<int?>("NombreAutreNationalites")
                        .HasColumnType("int");

                    b.Property<int?>("NombreCameroun")
                        .HasColumnType("int");

                    b.Property<int?>("NombreCotedIvoire")
                        .HasColumnType("int");

                    b.Property<int?>("NombreEnfants")
                        .HasColumnType("int");

                    b.Property<int?>("NombreFemmes")
                        .HasColumnType("int");

                    b.Property<int?>("NombreGuinee")
                        .HasColumnType("int");

                    b.Property<int?>("NombreHommes")
                        .HasColumnType("int");

                    b.Property<int?>("NombreMENA")
                        .HasColumnType("int");

                    b.Property<int?>("NombreMali")
                        .HasColumnType("int");

                    b.Property<int>("NombreMigrants")
                        .HasColumnType("int");

                    b.Property<int?>("NombreNigeria")
                        .HasColumnType("int");

                    b.Property<int?>("NombreRDC")
                        .HasColumnType("int");

                    b.Property<int?>("NombreSenegal")
                        .HasColumnType("int");

                    b.Property<int?>("NombreSoudan")
                        .HasColumnType("int");

                    b.Property<int?>("NombreSudsoudan")
                        .HasColumnType("int");

                    b.Property<int>("SourceInformation")
                        .HasColumnType("int");

                    b.Property<int>("TypeEvenement")
                        .HasColumnType("int");

                    b.Property<int>("TypeMigrants")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.Property<int>("VerificationStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("VeilleContextuelle");
                });

            modelBuilder.Entity("MS2Api.Model.DossierPersonnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BenificierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LieuxDintervention")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenificierId")
                        .IsUnique();

                    b.ToTable("DossierPersonnel");
                });

            modelBuilder.Entity("MS2Api.Model.ParcoursMigratoire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AnneeEntree")
                        .HasColumnType("datetime2");

                    b.Property<string>("AutreMotif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<int?>("Duree")
                        .HasColumnType("int");

                    b.Property<int?>("DureeEntree")
                        .HasColumnType("int");

                    b.Property<string>("MotifDepart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("NouvelleArrivante")
                        .HasColumnType("bit");

                    b.Property<string>("VilleEntree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("ParcoursMigratoire");
                });

            modelBuilder.Entity("MS2Api.Model.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonneType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personnes", (string)null);

                    b.HasDiscriminator<string>("PersonneType").HasValue("Personne");
                });

            modelBuilder.Entity("MS2Api.Model.SituationAdministrative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("ActeDeNaissance")
                        .HasColumnType("bit");

                    b.Property<bool?>("AucunPiece")
                        .HasColumnType("bit");

                    b.Property<bool?>("AucunTite")
                        .HasColumnType("bit");

                    b.Property<string>("Autre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CarteConsulaire")
                        .HasColumnType("bit");

                    b.Property<bool?>("CarteMarocaine")
                        .HasColumnType("bit");

                    b.Property<bool?>("CarteSejourValid")
                        .HasColumnType("bit");

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<bool?>("RecepisseDedemande")
                        .HasColumnType("bit");

                    b.Property<bool?>("StatusDeRefugie")
                        .HasColumnType("bit");

                    b.Property<bool?>("ValidationPassport")
                        .HasColumnType("bit");

                    b.Property<bool?>("Visa")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("SituationAdministrative");
                });

            modelBuilder.Entity("MS2Api.Model.SituationFamiliale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Accompagne")
                        .HasColumnType("bit");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<bool?>("EnfantAcharge")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Mineur")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nombre")
                        .HasColumnType("int");

                    b.Property<string>("SituationMatrimoniale")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("SituationFamiliale");
                });

            modelBuilder.Entity("MS2Api.Model.SituationPsychologique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Autre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Enceinte")
                        .HasColumnType("datetime2");

                    b.Property<string>("Handicap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaladieChronique")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaladieMentale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SituationDeDetresse")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("SituationPsychologique");
                });

            modelBuilder.Entity("MS2Api.Model.SituationSocioEconomique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AutreHabit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AutreSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<string>("FormationPersonnel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NiveauEducation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("SituationSocioEconomique");
                });

            modelBuilder.Entity("MS2Api.Model.SituationViolence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DossierPersonnelId")
                        .HasColumnType("int");

                    b.Property<bool?>("Indicateur")
                        .HasColumnType("bit");

                    b.Property<string>("Victim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("VictimArretation")
                        .HasColumnType("bit");

                    b.Property<string>("Victimrefoulement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DossierPersonnelId")
                        .IsUnique()
                        .HasFilter("[DossierPersonnelId] IS NOT NULL");

                    b.ToTable("SituationViolence");
                });

            modelBuilder.Entity("MS2Api.Model.Benificier", b =>
                {
                    b.HasBaseType("MS2Api.Model.Personne");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationalite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaysOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeleUrgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeDetection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codeUnique")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("codeUnique")
                        .IsUnique()
                        .HasFilter("[codeUnique] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Benificier");
                });

            modelBuilder.Entity("MS2Api.Model.Utilisateur", b =>
                {
                    b.HasBaseType("MS2Api.Model.Personne");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Utilisateur");
                });

            modelBuilder.Entity("Admin.Models.Avis", b =>
                {
                    b.HasOne("MS2Api.Model.Benificier", "Benificier")
                        .WithMany("Avis")
                        .HasForeignKey("BenificierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benificier");
                });

            modelBuilder.Entity("Admin.Models.DossierMedical", b =>
                {
                    b.HasOne("MS2Api.Model.Benificier", "benificier")
                        .WithMany("DossierMedicals")
                        .HasForeignKey("BenificierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("benificier");
                });

            modelBuilder.Entity("Admin.Models.VeilleContextuelle", b =>
                {
                    b.HasOne("MS2Api.Model.Utilisateur", "Utilisateur")
                        .WithMany("veilleContextuelles")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("MS2Api.Model.DossierPersonnel", b =>
                {
                    b.HasOne("MS2Api.Model.Benificier", "Benificier")
                        .WithOne("Dossier")
                        .HasForeignKey("MS2Api.Model.DossierPersonnel", "BenificierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benificier");
                });

            modelBuilder.Entity("MS2Api.Model.ParcoursMigratoire", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("ParcoursMigratoire")
                        .HasForeignKey("MS2Api.Model.ParcoursMigratoire", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.SituationAdministrative", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("Administrative")
                        .HasForeignKey("MS2Api.Model.SituationAdministrative", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.SituationFamiliale", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("Familiale")
                        .HasForeignKey("MS2Api.Model.SituationFamiliale", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.SituationPsychologique", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("Psychologique")
                        .HasForeignKey("MS2Api.Model.SituationPsychologique", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.SituationSocioEconomique", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("SocioEconomique")
                        .HasForeignKey("MS2Api.Model.SituationSocioEconomique", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.SituationViolence", b =>
                {
                    b.HasOne("MS2Api.Model.DossierPersonnel", "Dossier")
                        .WithOne("Violence")
                        .HasForeignKey("MS2Api.Model.SituationViolence", "DossierPersonnelId");

                    b.Navigation("Dossier");
                });

            modelBuilder.Entity("MS2Api.Model.DossierPersonnel", b =>
                {
                    b.Navigation("Administrative");

                    b.Navigation("Familiale");

                    b.Navigation("ParcoursMigratoire");

                    b.Navigation("Psychologique");

                    b.Navigation("SocioEconomique");

                    b.Navigation("Violence");
                });

            modelBuilder.Entity("MS2Api.Model.Benificier", b =>
                {
                    b.Navigation("Avis");

                    b.Navigation("Dossier");

                    b.Navigation("DossierMedicals");
                });

            modelBuilder.Entity("MS2Api.Model.Utilisateur", b =>
                {
                    b.Navigation("veilleContextuelles");
                });
#pragma warning restore 612, 618
        }
    }
}