using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class UpdatingtheFormcontrolsupdatingControlTypetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ControlType",
                table: "RequestFormControls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ControlType",
                table: "RequestFormControls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
