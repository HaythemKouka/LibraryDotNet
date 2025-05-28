using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibrairieReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddAuteurEtChampsLivre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Livres");

            migrationBuilder.AddColumn<int>(
                name: "AnneePublication",
                table: "Livres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuteurId",
                table: "Livres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Livres",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Langue",
                table: "Livres",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaisonEdition",
                table: "Livres",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NombrePages",
                table: "Livres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Nationalite = table.Column<string>(type: "text", nullable: true),
                    Biographie = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livres_AuteurId",
                table: "Livres",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres");

            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropIndex(
                name: "IX_Livres_AuteurId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "AnneePublication",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Langue",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "MaisonEdition",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "NombrePages",
                table: "Livres");

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Livres",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
