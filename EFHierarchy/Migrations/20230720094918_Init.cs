using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFHierarchy.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TPHParent",
                columns: table => new
                {
                    TPHParentField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TPHChild1Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPHChild2Field = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TPTParent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TPTParentField = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTParent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TPTChild1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TPTChild1Field = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTChild1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPTChild1_TPTParent_Id",
                        column: x => x.Id,
                        principalTable: "TPTParent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPTChild2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TPTChild2Field = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTChild2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPTChild2_TPTParent_Id",
                        column: x => x.Id,
                        principalTable: "TPTParent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPHParent");

            migrationBuilder.DropTable(
                name: "TPTChild1");

            migrationBuilder.DropTable(
                name: "TPTChild2");

            migrationBuilder.DropTable(
                name: "TPTParent");
        }
    }
}
