using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mrozik.Nebraska.Data.Migrations
{
    public partial class OrdersandDepartmentsmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newSchema: "dbo");
        }
    }
}
