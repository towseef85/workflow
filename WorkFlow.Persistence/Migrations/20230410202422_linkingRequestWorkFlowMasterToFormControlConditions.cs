using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class linkingRequestWorkFlowMasterToFormControlConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequstFormControlConditions_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                column: "RequestWorkFlowMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequstFormControlConditions_RequestWorkFlowMasters_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                column: "RequestWorkFlowMasterId",
                principalTable: "RequestWorkFlowMasters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequstFormControlConditions_RequestWorkFlowMasters_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropIndex(
                name: "IX_RequstFormControlConditions_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropColumn(
                name: "RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");
        }
    }
}
