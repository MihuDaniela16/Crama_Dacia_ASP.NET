using Microsoft.EntityFrameworkCore.Migrations;

namespace Crama_Dacia_ASP.NET.Migrations
{
    public partial class VinTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoiID",
                table: "Vin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Soi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSoi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VinTip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinID = table.Column<int>(type: "int", nullable: false),
                    TipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinTip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VinTip_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinTip_Vin_VinID",
                        column: x => x.VinID,
                        principalTable: "Vin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vin_SoiID",
                table: "Vin",
                column: "SoiID");

            migrationBuilder.CreateIndex(
                name: "IX_VinTip_TipID",
                table: "VinTip",
                column: "TipID");

            migrationBuilder.CreateIndex(
                name: "IX_VinTip_VinID",
                table: "VinTip",
                column: "VinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Soi_SoiID",
                table: "Vin",
                column: "SoiID",
                principalTable: "Soi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Soi_SoiID",
                table: "Vin");

            migrationBuilder.DropTable(
                name: "Soi");

            migrationBuilder.DropTable(
                name: "VinTip");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropIndex(
                name: "IX_Vin_SoiID",
                table: "Vin");

            migrationBuilder.DropColumn(
                name: "SoiID",
                table: "Vin");
        }
    }
}
