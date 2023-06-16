using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class addingFormConditionAndOperator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestControlConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArbDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscalationHours = table.Column<int>(type: "int", nullable: false),
                    FormControlId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestControlConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestControlConditions_RequestFormControls_FormControlId",
                        column: x => x.FormControlId,
                        principalTable: "RequestFormControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestConditionOperators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormControlConditionId = table.Column<int>(type: "int", nullable: false),
                    Operand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    RequestControlConditionsId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestConditionOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestConditionOperators_RequestControlConditions_RequestControlConditionsId",
                        column: x => x.RequestControlConditionsId,
                        principalTable: "RequestControlConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestConditionOperators_RequestControlConditionsId",
                table: "RequestConditionOperators",
                column: "RequestControlConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestControlConditions_FormControlId",
                table: "RequestControlConditions",
                column: "FormControlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestConditionOperators");

            migrationBuilder.DropTable(
                name: "RequestControlConditions");
        }
    }
}
