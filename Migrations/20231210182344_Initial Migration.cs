using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationGSecole.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<Guid>(name: "Id_Admin", type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    Idcours = table.Column<Guid>(name: "Id_cours", type: "uniqueidentifier", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.Idcours);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    IdGroupe = table.Column<Guid>(name: "Id_Groupe", type: "uniqueidentifier", nullable: false),
                    NumeroDeGroupe = table.Column<int>(type: "int", nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.IdGroupe);
                });

            migrationBuilder.CreateTable(
                name: "Profs",
                columns: table => new
                {
                    IdProf = table.Column<Guid>(name: "Id_Prof", type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profs", x => x.IdProf);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    IdEtudiant = table.Column<Guid>(name: "Id_Etudiant", type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Note1 = table.Column<double>(type: "float", nullable: false),
                    Note2 = table.Column<double>(type: "float", nullable: false),
                    GroupeIdGroupe = table.Column<Guid>(name: "GroupeId_Groupe", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.IdEtudiant);
                    table.ForeignKey(
                        name: "FK_Etudiants_Groupes_GroupeId_Groupe",
                        column: x => x.GroupeIdGroupe,
                        principalTable: "Groupes",
                        principalColumn: "Id_Groupe");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_GroupeId_Groupe",
                table: "Etudiants",
                column: "GroupeId_Groupe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Profs");

            migrationBuilder.DropTable(
                name: "Groupes");
        }
    }
}
