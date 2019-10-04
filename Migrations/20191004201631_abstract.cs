using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDemo.Migrations
{
    public partial class @abstract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_SlotTypes_TypeId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Slots_SlotArticleId_SlotTypeId",
                table: "Elements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elements",
                table: "Elements");

            migrationBuilder.RenameTable(
                name: "Elements",
                newName: "Element");

            migrationBuilder.RenameIndex(
                name: "IX_Elements_SlotArticleId_SlotTypeId",
                table: "Element",
                newName: "IX_Element_SlotArticleId_SlotTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Elements_TypeId",
                table: "Element",
                newName: "IX_Element_TypeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Element",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Element",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Element",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Element",
                table: "Element",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_SlotTypes_TypeId",
                table: "Element",
                column: "TypeId",
                principalTable: "SlotTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Slots_SlotArticleId_SlotTypeId",
                table: "Element",
                columns: new[] { "SlotArticleId", "SlotTypeId" },
                principalTable: "Slots",
                principalColumns: new[] { "ArticleId", "SlotTypeId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_SlotTypes_TypeId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Slots_SlotArticleId_SlotTypeId",
                table: "Element");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Element",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Element");

            migrationBuilder.RenameTable(
                name: "Element",
                newName: "Elements");

            migrationBuilder.RenameIndex(
                name: "IX_Element_SlotArticleId_SlotTypeId",
                table: "Elements",
                newName: "IX_Elements_SlotArticleId_SlotTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Element_TypeId",
                table: "Elements",
                newName: "IX_Elements_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elements",
                table: "Elements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_SlotTypes_TypeId",
                table: "Elements",
                column: "TypeId",
                principalTable: "SlotTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Slots_SlotArticleId_SlotTypeId",
                table: "Elements",
                columns: new[] { "SlotArticleId", "SlotTypeId" },
                principalTable: "Slots",
                principalColumns: new[] { "ArticleId", "SlotTypeId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
