using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoGaveUpProbablyCQRS.Data.Migrations
{
    public partial class addedrequiredtofluentconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoThings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoThings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
