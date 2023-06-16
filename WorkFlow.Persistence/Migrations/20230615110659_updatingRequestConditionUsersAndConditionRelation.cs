using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    public partial class updatingRequestConditionUsersAndConditionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestConditionUsers_RequestControlConditions_RequestControlConditionsId",
                table: "RequestConditionUsers");

            migrationBuilder.DropIndex(
                name: "IX_RequestConditionUsers_RequestControlConditionsId",
                table: "RequestConditionUsers");

            migrationBuilder.DropColumn(
                name: "RequestControlConditionsId",
                table: "RequestConditionUsers");

            migrationBuilder.CreateTable(
                name: "RequestConditionUsersRequestControlConditions",
                columns: table => new
                {
                    RequestConditionUsersId = table.Column<int>(type: "int", nullable: false),
                    RequestControlConditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestConditionUsersRequestControlConditions", x => new { x.RequestConditionUsersId, x.RequestControlConditionsId });
                    table.ForeignKey(
                        name: "FK_RequestConditionUsersRequestControlConditions_RequestConditionUsers_RequestConditionUsersId",
                        column: x => x.RequestConditionUsersId,
                        principalTable: "RequestConditionUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestConditionUsersRequestControlConditions_RequestControlConditions_RequestControlConditionsId",
                        column: x => x.RequestControlConditionsId,
                        principalTable: "RequestControlConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestConditionUsersRequestControlConditions_RequestControlConditionsId",
                table: "RequestConditionUsersRequestControlConditions",
                column: "RequestControlConditionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestConditionUsersRequestControlConditions");

            migrationBuilder.AddColumn<int>(
                name: "RequestControlConditionsId",
                table: "RequestConditionUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestConditionUsers_RequestControlConditionsId",
                table: "RequestConditionUsers",
                column: "RequestControlConditionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestConditionUsers_RequestControlConditions_RequestControlConditionsId",
                table: "RequestConditionUsers",
                column: "RequestControlConditionsId",
                principalTable: "RequestControlConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
