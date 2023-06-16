using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class updatingtheconditionanduserleveltabletomanaytomanyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestFormControlConditionUserLevels_RequstFormControlConditions_RequestConditionId",
                table: "RequestFormControlConditionUserLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_RequstFormControlConditions_RequestFormControls_FormControlId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequstFormControlConditions_RequestWorkFlowMasters_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropIndex(
                name: "IX_RequstFormControlConditions_FormControlId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropIndex(
                name: "IX_RequstFormControlConditions_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropIndex(
                name: "IX_RequestFormControlConditionUserLevels_RequestConditionId",
                table: "RequestFormControlConditionUserLevels");

            migrationBuilder.DropColumn(
                name: "FormControlId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropColumn(
                name: "RequestWorkFlowMasterId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropColumn(
                name: "RequestConditionId",
                table: "RequestFormControlConditionUserLevels");

            migrationBuilder.AddColumn<int>(
                name: "RequestFormControlsId",
                table: "RequstFormControlConditions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkFlowConditionsAndUserLevels",
                columns: table => new
                {
                    FormControlConditionId = table.Column<int>(type: "int", nullable: false),
                    UserLevelConditionId = table.Column<int>(type: "int", nullable: false),
                    RequestFormControlConditionUserLevelsId = table.Column<int>(type: "int", nullable: false),
                    RequestWorkFlowMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowConditionsAndUserLevels", x => new { x.UserLevelConditionId, x.FormControlConditionId });
                    table.ForeignKey(
                        name: "FK_WorkFlowConditionsAndUserLevels_RequestFormControlConditionUserLevels_RequestFormControlConditionUserLevelsId",
                        column: x => x.RequestFormControlConditionUserLevelsId,
                        principalTable: "RequestFormControlConditionUserLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkFlowConditionsAndUserLevels_RequestWorkFlowMasters_RequestWorkFlowMasterId",
                        column: x => x.RequestWorkFlowMasterId,
                        principalTable: "RequestWorkFlowMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkFlowConditionsAndUserLevels_RequstFormControlConditions_FormControlConditionId",
                        column: x => x.FormControlConditionId,
                        principalTable: "RequstFormControlConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequstFormControlConditions_RequestFormControlsId",
                table: "RequstFormControlConditions",
                column: "RequestFormControlsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowConditionsAndUserLevels_FormControlConditionId",
                table: "WorkFlowConditionsAndUserLevels",
                column: "FormControlConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowConditionsAndUserLevels_RequestFormControlConditionUserLevelsId",
                table: "WorkFlowConditionsAndUserLevels",
                column: "RequestFormControlConditionUserLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowConditionsAndUserLevels_RequestWorkFlowMasterId",
                table: "WorkFlowConditionsAndUserLevels",
                column: "RequestWorkFlowMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequstFormControlConditions_RequestFormControls_RequestFormControlsId",
                table: "RequstFormControlConditions",
                column: "RequestFormControlsId",
                principalTable: "RequestFormControls",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequstFormControlConditions_RequestFormControls_RequestFormControlsId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropTable(
                name: "WorkFlowConditionsAndUserLevels");

            migrationBuilder.DropIndex(
                name: "IX_RequstFormControlConditions_RequestFormControlsId",
                table: "RequstFormControlConditions");

            migrationBuilder.DropColumn(
                name: "RequestFormControlsId",
                table: "RequstFormControlConditions");

            migrationBuilder.AddColumn<int>(
                name: "FormControlId",
                table: "RequstFormControlConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestConditionId",
                table: "RequestFormControlConditionUserLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequstFormControlConditions_FormControlId",
                table: "RequstFormControlConditions",
                column: "FormControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RequstFormControlConditions_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                column: "RequestWorkFlowMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_RequestConditionId",
                table: "RequestFormControlConditionUserLevels",
                column: "RequestConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestFormControlConditionUserLevels_RequstFormControlConditions_RequestConditionId",
                table: "RequestFormControlConditionUserLevels",
                column: "RequestConditionId",
                principalTable: "RequstFormControlConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequstFormControlConditions_RequestFormControls_FormControlId",
                table: "RequstFormControlConditions",
                column: "FormControlId",
                principalTable: "RequestFormControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequstFormControlConditions_RequestWorkFlowMasters_RequestWorkFlowMasterId",
                table: "RequstFormControlConditions",
                column: "RequestWorkFlowMasterId",
                principalTable: "RequestWorkFlowMasters",
                principalColumn: "Id");
        }
    }
}
