using Microsoft.EntityFrameworkCore.Migrations;

namespace AvivatecParty.Infra.Data.Migrations
{
    public partial class AvivatecPartyVer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Participantes",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Locais",
                type: "varchar(150)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Locais");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Participantes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }
    }
}