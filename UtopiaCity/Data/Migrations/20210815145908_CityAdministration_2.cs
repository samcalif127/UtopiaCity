﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class CityAdministration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {                   

            //migrationBuilder.AddColumn<string>(
            //    name: "ResidentAccountId",
            //    table: "Tickets",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Marriage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstPersonId = table.Column<string>(nullable: false),
                    SecondPersonId = table.Column<string>(nullable: false),
                    FirstPersonData = table.Column<string>(nullable: true),
                    SecondPersonData = table.Column<string>(nullable: true),
                    MarriageDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentAccount",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    MarriageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentAccount_Marriage_MarriageId",
                        column: x => x.MarriageId,
                        principalTable: "Marriage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tickets_ResidentAccountId",
            //    table: "Tickets",
            //    column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccount_MarriageId",
                table: "ResidentAccount",
                column: "MarriageId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tickets_ResidentAccount_ResidentAccountId",
            //    table: "Tickets",
            //    column: "ResidentAccountId",
            //    principalTable: "ResidentAccount",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ResidentAccount_ResidentAccountId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ResidentAccount");

            migrationBuilder.DropTable(
                name: "Marriage");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ResidentAccountId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ResidentAccountId",
                table: "Tickets");
        }
    }
}