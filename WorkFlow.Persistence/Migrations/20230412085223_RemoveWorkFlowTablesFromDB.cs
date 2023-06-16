using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class RemoveWorkFlowTablesFromDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestWorkFlowMasters_RequestForms_RequestFormId",
                table: "RequestWorkFlowMasters");

            migrationBuilder.DropTable(
                name: "WorkFlowConditionsAndUserLevels");

            migrationBuilder.DropTable(
                name: "RequestFormControlConditionUserLevels");

            migrationBuilder.DropTable(
                name: "RequstFormControlConditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestWorkFlowMasters",
                table: "RequestWorkFlowMasters");

            migrationBuilder.DropIndex(
                name: "IX_RequestWorkFlowMasters_RequestFormId",
                table: "RequestWorkFlowMasters");

            migrationBuilder.RenameTable(
                name: "RequestWorkFlowMasters",
                newName: "RequestWorkFlowMaster");

            migrationBuilder.AddColumn<int>(
                name: "RequestFormsId",
                table: "RequestWorkFlowMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestWorkFlowMaster",
                table: "RequestWorkFlowMaster",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestWorkFlowMaster_RequestFormsId",
                table: "RequestWorkFlowMaster",
                column: "RequestFormsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestWorkFlowMaster_RequestForms_RequestFormsId",
                table: "RequestWorkFlowMaster",
                column: "RequestFormsId",
                principalTable: "RequestForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestWorkFlowMaster_RequestForms_RequestFormsId",
                table: "RequestWorkFlowMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestWorkFlowMaster",
                table: "RequestWorkFlowMaster");

            migrationBuilder.DropIndex(
                name: "IX_RequestWorkFlowMaster_RequestFormsId",
                table: "RequestWorkFlowMaster");

            migrationBuilder.DropColumn(
                name: "RequestFormsId",
                table: "RequestWorkFlowMaster");

            migrationBuilder.RenameTable(
                name: "RequestWorkFlowMaster",
                newName: "RequestWorkFlowMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestWorkFlowMasters",
                table: "RequestWorkFlowMasters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RequestFormControlConditionUserLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPositionId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFormControlConditionUserLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestFormControlConditionUserLevels_Positions_UserPositionId",
                        column: x => x.UserPositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestFormControlConditionUserLevels_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequstFormControlConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionOperator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RequestFormControlsId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequstFormControlConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequstFormControlConditions_RequestFormControls_RequestFormControlsId",
                        column: x => x.RequestFormControlsId,
                        principalTable: "RequestFormControls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowConditionsAndUserLevels",
                columns: table => new
                {
                    UserLevelConditionId = table.Column<int>(type: "int", nullable: false),
                    FormControlConditionId = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_RequestWorkFlowMasters_RequestFormId",
                table: "RequestWorkFlowMasters",
                column: "RequestFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_UserPositionId",
                table: "RequestFormControlConditionUserLevels",
                column: "UserPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_UserTypeId",
                table: "RequestFormControlConditionUserLevels",
                column: "UserTypeId");

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
                name: "FK_RequestWorkFlowMasters_RequestForms_RequestFormId",
                table: "RequestWorkFlowMasters",
                column: "RequestFormId",
                principalTable: "RequestForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
