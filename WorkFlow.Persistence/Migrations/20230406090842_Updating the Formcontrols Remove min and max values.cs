using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class UpdatingtheFormcontrolsRemoveminandmaxvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "RequestFormControls");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "RequestFormControls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxValue",
                table: "RequestFormControls",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinValue",
                table: "RequestFormControls",
                type: "float",
                nullable: true);
        }
    }
}
