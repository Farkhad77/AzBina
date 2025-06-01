using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzBina.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Ads_AdId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Ads_AdId1",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_AdId1",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "AdId1",
                table: "Favorites");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Ads_AdId",
                table: "Favorites",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Ads_AdId",
                table: "Favorites");

            migrationBuilder.AddColumn<Guid>(
                name: "AdId1",
                table: "Favorites",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AdId1",
                table: "Favorites",
                column: "AdId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Ads_AdId",
                table: "Favorites",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Ads_AdId1",
                table: "Favorites",
                column: "AdId1",
                principalTable: "Ads",
                principalColumn: "Id");
        }
    }
}
