using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class updatingconditionandoperatorsrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestConditionOperators_RequestControlConditions_RequestControlConditionsId",
                table: "RequestConditionOperators");

            migrationBuilder.DropIndex(
                name: "IX_RequestConditionOperators_RequestControlConditionsId",
                table: "RequestConditionOperators");

            migrationBuilder.RenameColumn(
                name: "RequestControlConditionsId",
                table: "RequestConditionOperators",
                newName: "FormControlId");

            migrationBuilder.RenameColumn(
                name: "FormControlConditionId",
                table: "RequestConditionOperators",
                newName: "ControlConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestConditionOperators_ControlConditionsId",
                table: "RequestConditionOperators",
                column: "ControlConditionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestConditionOperators_RequestControlConditions_ControlConditionsId",
                table: "RequestConditionOperators",
                column: "ControlConditionsId",
                principalTable: "RequestControlConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestConditionOperators_RequestControlConditions_ControlConditionsId",
                table: "RequestConditionOperators");

            migrationBuilder.DropIndex(
                name: "IX_RequestConditionOperators_ControlConditionsId",
                table: "RequestConditionOperators");

            migrationBuilder.RenameColumn(
                name: "FormControlId",
                table: "RequestConditionOperators",
                newName: "RequestControlConditionsId");

            migrationBuilder.RenameColumn(
                name: "ControlConditionsId",
                table: "RequestConditionOperators",
                newName: "FormControlConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestConditionOperators_RequestControlConditionsId",
                table: "RequestConditionOperators",
                column: "RequestControlConditionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestConditionOperators_RequestControlConditions_RequestControlConditionsId",
                table: "RequestConditionOperators",
                column: "RequestControlConditionsId",
                principalTable: "RequestControlConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
