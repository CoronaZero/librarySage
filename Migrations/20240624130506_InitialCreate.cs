using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drugSystemBlazor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientName = table.Column<string>(type: "TEXT", nullable: false),
                    IsPatientTakes = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDrugs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrugID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriptionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Drugs_DrugID",
                        column: x => x.DrugID,
                        principalTable: "Drugs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "DrugName",
                table: "Drugs",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugs_DrugID",
                table: "PrescriptionDrugs",
                column: "DrugID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugs_PrescriptionID",
                table: "PrescriptionDrugs",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "PatientNameIndex",
                table: "Prescriptions",
                column: "PatientName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionDrugs");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
