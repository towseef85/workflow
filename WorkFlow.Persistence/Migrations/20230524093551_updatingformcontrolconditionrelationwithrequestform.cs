using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class updatingformcontrolconditionrelationwithrequestform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestControlConditions_RequestFormControls_FormControlId",
                table: "RequestControlConditions");

            migrationBuilder.DropTable(
                name: "RequestWorkFlowMaster");

            migrationBuilder.RenameColumn(
                name: "FormControlId",
                table: "RequestControlConditions",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestControlConditions_FormControlId",
                table: "RequestControlConditions",
                newName: "IX_RequestControlConditions_FormId");

            migrationBuilder.AddColumn<int>(
                name: "RequestFormControlsId",
                table: "RequestControlConditions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RestrictForm",
                table: "RequestControlConditions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_RequestControlConditions_RequestFormControlsId",
                table: "RequestControlConditions",
                column: "RequestFormControlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestControlConditions_RequestFormControls_RequestFormControlsId",
                table: "RequestControlConditions",
                column: "RequestFormControlsId",
                principalTable: "RequestFormControls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestControlConditions_RequestForms_FormId",
                table: "RequestControlConditions",
                column: "FormId",
                principalTable: "RequestForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestControlConditions_RequestFormControls_RequestFormControlsId",
                table: "RequestControlConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestControlConditions_RequestForms_FormId",
                table: "RequestControlConditions");

            migrationBuilder.DropIndex(
                name: "IX_RequestControlConditions_RequestFormControlsId",
                table: "RequestControlConditions");

            migrationBuilder.DropColumn(
                name: "RequestFormControlsId",
                table: "RequestControlConditions");

            migrationBuilder.DropColumn(
                name: "RestrictForm",
                table: "RequestControlConditions");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "RequestControlConditions",
                newName: "FormControlId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestControlConditions_FormId",
                table: "RequestControlConditions",
                newName: "IX_RequestControlConditions_FormControlId");

            migrationBuilder.CreateTable(
                name: "RequestWorkFlowMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestFormsId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RequestFormId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkFlowName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestWorkFlowMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestWorkFlowMaster_RequestForms_RequestFormsId",
                        column: x => x.RequestFormsId,
                        principalTable: "RequestForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestWorkFlowMaster_RequestFormsId",
                table: "RequestWorkFlowMaster",
                column: "RequestFormsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestControlConditions_RequestFormControls_FormControlId",
                table: "RequestControlConditions",
                column: "FormControlId",
                principalTable: "RequestFormControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
