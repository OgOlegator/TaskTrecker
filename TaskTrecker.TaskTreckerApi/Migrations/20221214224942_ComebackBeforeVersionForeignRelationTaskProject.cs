using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrecker.TaskTreckerApi.Migrations
{
    /// <inheritdoc />
    public partial class ComebackBeforeVersionForeignRelationTaskProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Task_Project",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_IdProject",
                table: "Tasks",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_IdProject",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Task_Project",
                table: "Tasks",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
