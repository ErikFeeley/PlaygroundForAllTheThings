using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoBase.Data.Migrations
{
    public partial class madeappuserforeignkeyrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplicationUserId",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplicationUserId",
                table: "ToDos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplicationUserId",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplicationUserId",
                table: "ToDos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
