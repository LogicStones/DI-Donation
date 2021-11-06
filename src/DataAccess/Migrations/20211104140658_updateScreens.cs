using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateScreens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedAt",
                table: "Screens",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "AddedAt",
                table: "Screens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
