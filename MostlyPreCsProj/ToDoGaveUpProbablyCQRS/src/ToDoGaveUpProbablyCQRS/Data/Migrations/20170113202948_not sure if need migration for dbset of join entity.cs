using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoGaveUpProbablyCQRS.Data.Migrations
{
    public partial class notsureifneedmigrationfordbsetofjoinentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThingTag_Tags_TagId",
                table: "ToDoThingTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThingTag_ToDoThings_ToDoThingId",
                table: "ToDoThingTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoThingTag",
                table: "ToDoThingTag");

            migrationBuilder.RenameTable(
                name: "ToDoThingTag",
                newName: "ToDoThingTags");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoThingTag_TagId",
                table: "ToDoThingTags",
                newName: "IX_ToDoThingTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoThingTags",
                table: "ToDoThingTags",
                columns: new[] { "ToDoThingId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThingTags_Tags_TagId",
                table: "ToDoThingTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThingTags_ToDoThings_ToDoThingId",
                table: "ToDoThingTags",
                column: "ToDoThingId",
                principalTable: "ToDoThings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThingTags_Tags_TagId",
                table: "ToDoThingTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoThingTags_ToDoThings_ToDoThingId",
                table: "ToDoThingTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoThingTags",
                table: "ToDoThingTags");

            migrationBuilder.RenameTable(
                name: "ToDoThingTags",
                newName: "ToDoThingTag");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoThingTags_TagId",
                table: "ToDoThingTag",
                newName: "IX_ToDoThingTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoThingTag",
                table: "ToDoThingTag",
                columns: new[] { "ToDoThingId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThingTag_Tags_TagId",
                table: "ToDoThingTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoThingTag_ToDoThings_ToDoThingId",
                table: "ToDoThingTag",
                column: "ToDoThingId",
                principalTable: "ToDoThings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
