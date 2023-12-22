using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationGSecole.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Etudiants",
                columns: table => new
                {
                    IdEtudiant = table.Column<Guid>(name: "Id_Etudiant", type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCours = table.Column<Guid>(name: "Id_Cours", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.IdEtudiant);
                    table.ForeignKey(
                        name: "FK_Etudiants_Cours_Id_Cours",
                        column: x => x.IdCours,
                        principalTable: "Cours",
                        principalColumn: "Id_cours",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profs",
                columns: table => new
                {
                    IdProf = table.Column<Guid>(name: "Id_Prof", type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCours = table.Column<Guid>(name: "Id_Cours", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profs", x => x.IdProf);
                    table.ForeignKey(
                        name: "FK_Profs_Cours_Id_Cours",
                        column: x => x.IdCours,
                        principalTable: "Cours",
                        principalColumn: "Id_cours",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Id_Cours",
                table: "Etudiants",
                column: "Id_Cours");

            migrationBuilder.CreateIndex(
                name: "IX_Profs_Id_Cours",
                table: "Profs",
                column: "Id_Cours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Profs");

            migrationBuilder.DropTable(
                name: "Cours");
        }
    }
}
