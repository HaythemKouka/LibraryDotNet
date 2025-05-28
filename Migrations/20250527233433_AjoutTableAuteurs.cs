using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrairieReservation.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTableAuteurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur");

            migrationBuilder.RenameTable(
                name: "Auteur",
                newName: "Auteurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Auteurs_AuteurId",
                table: "Livres",
                column: "AuteurId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Auteurs_AuteurId",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs");

            migrationBuilder.RenameTable(
                name: "Auteurs",
                newName: "Auteur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
