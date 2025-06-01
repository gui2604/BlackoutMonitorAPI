using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackoutMonitorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceRelationToAlert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Alerts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_DeviceId",
                table: "Alerts",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Devices_DeviceId",
                table: "Alerts",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Devices_DeviceId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_DeviceId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Devices",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
