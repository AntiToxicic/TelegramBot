using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityDataAndRemoveEntitiesLikeCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "PicturesInfos");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CraatedBy",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CraatedBy",
                table: "PicturesInfos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CraatedBy",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Likes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CraatedBy",
                table: "PicturesInfos");

            migrationBuilder.DropColumn(
                name: "CraatedBy",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.AddColumn<long>(
                name: "LikeCount",
                table: "PicturesInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
