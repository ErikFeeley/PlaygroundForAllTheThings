using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoGaveUpProbablyCQRS.Data.Migrations
{
    public partial class fixedkeyforappusernavprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId1",
                table: "ToDoThings");

            migrationBuilder.DropIndex(
                name: "IX_ToDoThings_ApplicationUserId1",
                table: "ToDoThings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ToDoThings");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoThings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ToDoThings_ApplicationUserId",
                table: "ToDoThings",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId",
                table: "ToDoThings");

            migrationBuilder.DropIndex(
                name: "IX_ToDoThings_ApplicationUserId",
                table: "ToDoThings");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ToDoThings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ToDoThings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoThings_ApplicationUserId1",
                table: "ToDoThings",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThings_AspNetUsers_ApplicationUserId1",
                table: "ToDoThings",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
