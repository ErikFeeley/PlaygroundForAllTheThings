using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDoGaveUpProbablyCQRS.Data.Migrations
{
    public partial class addedtagswithmanytomanyrelationshipwithtodothings : Migration
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

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoThingTag",
                columns: table => new
                {
                    ToDoThingId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoThingTag", x => new { x.ToDoThingId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ToDoThingTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoThingTag_ToDoThings_ToDoThingId",
                        column: x => x.ToDoThingId,
                        principalTable: "ToDoThings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoThingTag_TagId",
                table: "ToDoThingTag",
                column: "TagId");

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

            migrationBuilder.DropTable(
                name: "ToDoThingTag");

            migrationBuilder.DropTable(
                name: "Tags");

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
