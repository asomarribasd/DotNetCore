using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleJournal.Data.Migrations
{
    public partial class JournalChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_FollowerId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Posts_PostId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_FollowerId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Subscriptions",
                newName: "Follower");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Subscriptions",
                newName: "JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_PostId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_JournalId");

            migrationBuilder.AlterColumn<string>(
                name: "Follower",
                table: "Subscriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JournalId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    JournalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.JournalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_JournalId",
                table: "Posts",
                column: "JournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Journals_JournalId",
                table: "Posts",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "JournalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Journals_JournalId",
                table: "Subscriptions",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "JournalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Journals_JournalId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Journals_JournalId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropIndex(
                name: "IX_Posts_JournalId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "JournalId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "JournalId",
                table: "Subscriptions",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Follower",
                table: "Subscriptions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_JournalId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_PostId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Subscriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FollowerId",
                table: "Subscriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FollowerId",
                table: "Subscriptions",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_FollowerId",
                table: "Subscriptions",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Posts_PostId",
                table: "Subscriptions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
