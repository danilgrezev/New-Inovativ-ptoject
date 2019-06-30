using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend5.Migrations
{
    public partial class Mig08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_RecipientId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_SenderId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUsers_ClientId1",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUsers_EmployeeId1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ClientId1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_EmployeeId1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipientId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SenderId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "RecipientId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Task",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Task",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Task_ClientId",
                table: "Task",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeId",
                table: "Task",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipientId",
                table: "Comments",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId",
                table: "Comments",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_RecipientId",
                table: "Comments",
                column: "RecipientId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_SenderId",
                table: "Comments",
                column: "SenderId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUsers_ClientId",
                table: "Task",
                column: "ClientId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUsers_EmployeeId",
                table: "Task",
                column: "EmployeeId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_RecipientId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_SenderId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUsers_ClientId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUsers_EmployeeId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ClientId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_EmployeeId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipientId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SenderId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Task",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_ClientId1",
                table: "Task",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeId1",
                table: "Task",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipientId1",
                table: "Comments",
                column: "RecipientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId1",
                table: "Comments",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_RecipientId1",
                table: "Comments",
                column: "RecipientId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_SenderId1",
                table: "Comments",
                column: "SenderId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUsers_ClientId1",
                table: "Task",
                column: "ClientId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUsers_EmployeeId1",
                table: "Task",
                column: "EmployeeId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
