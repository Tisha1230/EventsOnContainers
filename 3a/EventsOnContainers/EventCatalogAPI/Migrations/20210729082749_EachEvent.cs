using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class EachEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eachEventTypes_Events_EventId",
                table: "eachEventTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_eachEventTypes_EventTypes_TypeId",
                table: "eachEventTypes");

            migrationBuilder.DropIndex(
                name: "IX_eachEventTypes_TypeId",
                table: "eachEventTypes");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EachEventId",
                table: "eachEventTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "eachEventTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_eachEventTypes_EachEventId",
                table: "eachEventTypes",
                column: "EachEventId");

            migrationBuilder.CreateIndex(
                name: "IX_eachEventTypes_EventTypeId",
                table: "eachEventTypes",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_eachEventTypes_Events_EachEventId",
                table: "eachEventTypes",
                column: "EachEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_eachEventTypes_EventTypes_EventTypeId",
                table: "eachEventTypes",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eachEventTypes_Events_EachEventId",
                table: "eachEventTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_eachEventTypes_EventTypes_EventTypeId",
                table: "eachEventTypes");

            migrationBuilder.DropIndex(
                name: "IX_eachEventTypes_EachEventId",
                table: "eachEventTypes");

            migrationBuilder.DropIndex(
                name: "IX_eachEventTypes_EventTypeId",
                table: "eachEventTypes");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EachEventId",
                table: "eachEventTypes");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "eachEventTypes");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_eachEventTypes_TypeId",
                table: "eachEventTypes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_eachEventTypes_Events_EventId",
                table: "eachEventTypes",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eachEventTypes_EventTypes_TypeId",
                table: "eachEventTypes",
                column: "TypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
