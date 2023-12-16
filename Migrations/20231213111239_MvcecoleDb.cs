using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationGSecole.Migrations
{
    /// <inheritdoc />
    public partial class MvcecoleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursId",
                table: "Profs");

            migrationBuilder.DropColumn(
                name: "CoursId",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Etudiants");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Cours",
                table: "Profs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Cours",
                table: "Groupes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Groupe",
                table: "Etudiants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Cours",
                table: "Profs");

            migrationBuilder.DropColumn(
                name: "Id_Cours",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "Id_Groupe",
                table: "Etudiants");

            migrationBuilder.AddColumn<int>(
                name: "CoursId",
                table: "Profs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoursId",
                table: "Groupes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Etudiants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
