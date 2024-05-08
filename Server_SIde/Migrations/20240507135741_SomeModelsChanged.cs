using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server_SIde.Migrations
{
    /// <inheritdoc />
    public partial class SomeModelsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeEquipments_Employees_EmployeeId",
                table: "FreeEquipments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "FreeEquipments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FreeEquipments_Employees_EmployeeId",
                table: "FreeEquipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeEquipments_Employees_EmployeeId",
                table: "FreeEquipments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "FreeEquipments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeEquipments_Employees_EmployeeId",
                table: "FreeEquipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
