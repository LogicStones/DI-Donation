using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class PassCodeAndBankAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<bool>(
            //    name: "isFeeInclusive",
            //    table: "Transaction",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "TimeStamp",
            //    table: "Transaction",
            //    type: "datetime(6)",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorPostCode",
            //    table: "Transaction",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorLastName",
            //    table: "Transaction",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorFirstName",
            //    table: "Transaction",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorAddress",
            //    table: "Transaction",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ReferenceTransactionId",
            //    table: "Transaction",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "Transaction",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "SubCategories",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "IsActive",
            //    table: "SubCategories",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ScreenPath",
            //    table: "Screens",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "IsActive",
            //    table: "Screens",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "AddedAt",
            //    table: "Screens",
            //    type: "datetime(6)",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "isActive",
            //    table: "Category",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Category",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "HasSubCategory",
            //    table: "Category",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TransactionId",
            //    table: "Campaigns",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Campaigns",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Campaigns",
            //    type: "datetime(6)",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Value",
            //    table: "AspNetUserTokens",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserTokens",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "TwoFactorEnabled",
            //    table: "AspNetUsers",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SecurityStamp",
            //    table: "AspNetUsers",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "PhoneNumberConfirmed",
            //    table: "AspNetUsers",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PhoneNumber",
            //    table: "AspNetUsers",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PasswordHash",
            //    table: "AspNetUsers",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<DateTimeOffset>(
            //    name: "LockoutEnd",
            //    table: "AspNetUsers",
            //    type: "datetime(6)",
            //    nullable: true,
            //    oldClrType: typeof(DateTimeOffset),
            //    oldType: "timestamp",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<bool>(
            //    name: "LockoutEnabled",
            //    table: "AspNetUsers",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "EmailConfirmed",
            //    table: "AspNetUsers",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    oldClrType: typeof(ulong),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "AspNetUsers",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "AspNetUsers",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserLogins",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderDisplayName",
            //    table: "AspNetUserLogins",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserClaims",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimValue",
            //    table: "AspNetUserClaims",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimType",
            //    table: "AspNetUserClaims",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "AspNetRoles",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "AspNetRoles",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetRoleClaims",
            //    type: "varchar(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(767)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimValue",
            //    table: "AspNetRoleClaims",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimType",
            //    table: "AspNetRoleClaims",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SumUpMerchantId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PassCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassCodes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "PassCodes");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "isFeeInclusive",
            //    table: "Transaction",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "TimeStamp",
            //    table: "Transaction",
            //    type: "datetime",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime(6)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorPostCode",
            //    table: "Transaction",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorLastName",
            //    table: "Transaction",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorFirstName",
            //    table: "Transaction",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SponsorAddress",
            //    table: "Transaction",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ReferenceTransactionId",
            //    table: "Transaction",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "Transaction",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "SubCategories",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "IsActive",
            //    table: "SubCategories",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ScreenPath",
            //    table: "Screens",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "IsActive",
            //    table: "Screens",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "AddedAt",
            //    table: "Screens",
            //    type: "datetime",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime(6)");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "isActive",
            //    table: "Category",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Category",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "HasSubCategory",
            //    table: "Category",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TransactionId",
            //    table: "Campaigns",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Campaigns",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Campaigns",
            //    type: "datetime",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime(6)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Value",
            //    table: "AspNetUserTokens",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserTokens",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "TwoFactorEnabled",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SecurityStamp",
            //    table: "AspNetUsers",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "PhoneNumberConfirmed",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PhoneNumber",
            //    table: "AspNetUsers",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PasswordHash",
            //    table: "AspNetUsers",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<DateTimeOffset>(
            //    name: "LockoutEnd",
            //    table: "AspNetUsers",
            //    type: "timestamp",
            //    nullable: true,
            //    oldClrType: typeof(DateTimeOffset),
            //    oldType: "datetime(6)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "LockoutEnabled",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<ulong>(
            //    name: "EmailConfirmed",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: false,
            //    oldClrType: typeof(bool),
            //    oldType: "tinyint(1)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "AspNetUsers",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "AspNetUsers",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserLogins",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderDisplayName",
            //    table: "AspNetUserLogins",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserClaims",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimValue",
            //    table: "AspNetUserClaims",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimType",
            //    table: "AspNetUserClaims",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "AspNetRoles",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "AspNetRoles",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetRoleClaims",
            //    type: "varchar(767)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(255)")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimValue",
            //    table: "AspNetRoleClaims",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ClaimType",
            //    table: "AspNetRoleClaims",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext",
            //    oldNullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
