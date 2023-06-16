using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class AddingFormControlConditionLevelsTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestFormControlConditionUserLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestConditionId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserPositionId = table.Column<int>(type: "int", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_RequestFormControlConditionUserLevels_RequstFormControlConditions_RequestConditionId",
                        column: x => x.RequestConditionId,
                        principalTable: "RequstFormControlConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestFormControlConditionUserLevels_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_RequestConditionId",
                table: "RequestFormControlConditionUserLevels",
                column: "RequestConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_UserPositionId",
                table: "RequestFormControlConditionUserLevels",
                column: "UserPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFormControlConditionUserLevels_UserTypeId",
                table: "RequestFormControlConditionUserLevels",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestFormControlConditionUserLevels");
        }
    }
}
