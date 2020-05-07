using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class addcolumerank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "star",
                table: "userLeanning",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "point",
                table: "userLeanning",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pointmaxStage",
                table: "rank",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pointmaxStage",
                table: "rank");

            migrationBuilder.AlterColumn<int>(
                name: "star",
                table: "userLeanning",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "point",
                table: "userLeanning",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
