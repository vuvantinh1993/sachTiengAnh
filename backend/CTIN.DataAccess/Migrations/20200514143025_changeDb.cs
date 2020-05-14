using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class changeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "extraone");

            migrationBuilder.DropColumn(
                name: "dataDb",
                table: "userLeanning");

            migrationBuilder.DropColumn(
                name: "filmleanning",
                table: "userLeanning");

            migrationBuilder.DropColumn(
                name: "listfrendid",
                table: "userLeanning");

            migrationBuilder.AddColumn<string>(
                name: "filmfinishforget",
                table: "userLeanning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "filmlearnning",
                table: "userLeanning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "listFilmLearned",
                table: "userLeanning",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WordFilm",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    textVn = table.Column<string>(maxLength: 500, nullable: true),
                    fullname = table.Column<string>(maxLength: 500, nullable: true),
                    textEn = table.Column<string>(maxLength: 500, nullable: true),
                    urlaudio = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    answerWrongEn = table.Column<string>(nullable: true),
                    answerWrongVn = table.Column<string>(nullable: true),
                    dataDb = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    size = table.Column<long>(nullable: true),
                    stt = table.Column<int>(nullable: false),
                    categoryfilmid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordFilm", x => x.id);
                    table.ForeignKey(
                        name: "FK_WordFilm_categoryfilm_categoryfilmid",
                        column: x => x.categoryfilmid,
                        principalTable: "categoryfilm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordFilm_categoryfilmid",
                table: "WordFilm",
                column: "categoryfilmid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordFilm");

            migrationBuilder.DropColumn(
                name: "filmfinishforget",
                table: "userLeanning");

            migrationBuilder.DropColumn(
                name: "filmlearnning",
                table: "userLeanning");

            migrationBuilder.DropColumn(
                name: "listFilmLearned",
                table: "userLeanning");

            migrationBuilder.AddColumn<string>(
                name: "dataDb",
                table: "userLeanning",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "filmleanning",
                table: "userLeanning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "listfrendid",
                table: "userLeanning",
                unicode: false,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "extraone",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    answerWrongEn = table.Column<string>(nullable: true),
                    answerWrongVn = table.Column<string>(nullable: true),
                    audio = table.Column<byte[]>(nullable: true),
                    categoryfilmid = table.Column<int>(nullable: false),
                    dataDb = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    doubtid = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    fullname = table.Column<string>(maxLength: 500, nullable: true),
                    size = table.Column<long>(nullable: true),
                    stt = table.Column<int>(nullable: false),
                    textEn = table.Column<string>(maxLength: 500, nullable: true),
                    textVn = table.Column<string>(maxLength: 500, nullable: true),
                    unselectid = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    urlaudio = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_extraone", x => x.id);
                    table.ForeignKey(
                        name: "FK_extraone_categoryfilm_categoryfilmid",
                        column: x => x.categoryfilmid,
                        principalTable: "categoryfilm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_extraone_categoryfilmid",
                table: "extraone",
                column: "categoryfilmid");
        }
    }
}
