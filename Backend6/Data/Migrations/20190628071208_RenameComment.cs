using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend6.Data.Migrations
{
    public partial class RenameComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ClientId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_EmployeeId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "EmployeeId1",
                table: "Comments",
                newName: "SenderId1");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Comments",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "ClientId1",
                table: "Comments",
                newName: "RecipientId1");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Comments",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_EmployeeId1",
                table: "Comments",
                newName: "IX_Comments_SenderId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ClientId1",
                table: "Comments",
                newName: "IX_Comments_RecipientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_RecipientId1",
                table: "Comments",
                column: "RecipientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId1",
                table: "Comments",
                column: "SenderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_RecipientId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "SenderId1",
                table: "Comments",
                newName: "EmployeeId1");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Comments",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "RecipientId1",
                table: "Comments",
                newName: "ClientId1");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Comments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_SenderId1",
                table: "Comments",
                newName: "IX_Comments_EmployeeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RecipientId1",
                table: "Comments",
                newName: "IX_Comments_ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ClientId1",
                table: "Comments",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_EmployeeId1",
                table: "Comments",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
