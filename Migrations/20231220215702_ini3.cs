using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationGSecole.Migrations
{
    /// <inheritdoc />
    public partial class ini3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiants_Groupes_GroupeId_Groupe",
                table: "Etudiants");

            migrationBuilder.DropIndex(
                name: "IX_Etudiants_GroupeId_Groupe",
                table: "Etudiants");

            migrationBuilder.DropColumn(
                name: "GroupeId_Groupe",
                table: "Etudiants");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_Id_Cours",
                table: "Groupes",
                column: "Id_Cours");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Cours_Id_Cours",
                table: "Groupes",
                column: "Id_Cours",
                principalTable: "Cours",
                principalColumn: "Id_cours",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Cours_Id_Cours",
                table: "Groupes");

            migrationBuilder.DropIndex(
                name: "IX_Groupes_Id_Cours",
                table: "Groupes");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupeId_Groupe",
                table: "Etudiants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_GroupeId_Groupe",
                table: "Etudiants",
                column: "GroupeId_Groupe");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiants_Groupes_GroupeId_Groupe",
                table: "Etudiants",
                column: "GroupeId_Groupe",
                principalTable: "Groupes",
                principalColumn: "Id_Groupe");
        }
    }
}
