using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CTIN.DataAccess.Migrations
{
    public partial class them_feedback3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contentFeedback = table.Column<string>(nullable: true),
                    replyFeedback = table.Column<string>(nullable: true),
                    cretedDateFeedback = table.Column<DateTime>(nullable: true),
                    replyDateFeedback = table.Column<DateTime>(nullable: true),
                    rateStar = table.Column<int>(nullable: true),
                    statusFeedback = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
