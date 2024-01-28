using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAProjekat23.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewProjectAdaptation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsSurveyed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "Users");

            migrationBuilder.AddColumn<ushort>(
                name: "PenaltyPoints",
                table: "Users",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ReservedBy",
                table: "Appointments",
                column: "ReservedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_ReservedBy",
                table: "Appointments",
                column: "ReservedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_ReservedBy",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ReservedBy",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PenaltyPoints",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Users",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSurveyed",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Users",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}
