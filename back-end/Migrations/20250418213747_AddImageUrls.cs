using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Packages_PackageId",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DestinationId",
                table: "Packages",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Destinations_DestinationId",
                table: "Packages",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Packages_PackageId",
                table: "Workouts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Destinations_DestinationId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Packages_PackageId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Packages_DestinationId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Destinations");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Packages_PackageId",
                table: "Workouts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }
    }
}
