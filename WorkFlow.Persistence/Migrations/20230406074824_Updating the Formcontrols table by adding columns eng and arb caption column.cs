using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class UpdatingtheFormcontrolstablebyaddingcolumnsengandarbcaptioncolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArbCaption",
                table: "RequestFormControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EngCaption",
                table: "RequestFormControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArbCaption",
                table: "RequestFormControls");

            migrationBuilder.DropColumn(
                name: "EngCaption",
                table: "RequestFormControls");
        }
    }
}
