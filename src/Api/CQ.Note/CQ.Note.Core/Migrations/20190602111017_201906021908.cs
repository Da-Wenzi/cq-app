using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQ.Note.Core.Migrations
{
    public partial class _201906021908 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "NoteContent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NoteAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Size = table.Column<int>(nullable: false),
                    NoteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteAttachment_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteAttachment_NoteId",
                table: "NoteAttachment",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteAttachment");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "NoteContent");
        }
    }
}
