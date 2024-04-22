using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema_dotNet.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ProducatorId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Producatori");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Produse");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProducatorId",
                table: "Produse",
                newName: "IX_Produse_ProducatorId");

            migrationBuilder.AddColumn<int>(
                name: "Pret",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producatori",
                table: "Producatori",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produse",
                table: "Produse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Producatori_ProducatorId",
                table: "Produse",
                column: "ProducatorId",
                principalTable: "Producatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Producatori_ProducatorId",
                table: "Produse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produse",
                table: "Produse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producatori",
                table: "Producatori");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Produse");

            migrationBuilder.RenameTable(
                name: "Produse",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Producatori",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Produse_ProducatorId",
                table: "Projects",
                newName: "IX_Projects_ProducatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProducatorId",
                table: "Projects",
                column: "ProducatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
