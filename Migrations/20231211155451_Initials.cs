using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebasDIF.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadesIngreso",
                columns: table => new
                {
                    IdUnidades = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rubro = table.Column<string>(type: "TEXT", nullable: true),
                    Unidad = table.Column<string>(type: "TEXT", nullable: true),
                    Recaudado = table.Column<double>(type: "REAL", nullable: true),
                    Mes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesIngreso", x => x.IdUnidades);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesPresupuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Ppto = table.Column<int>(type: "INTEGER", nullable: false),
                    Egreso_Imp_aprobado = table.Column<double>(type: "REAL", nullable: true),
                    Num_Mes = table.Column<int>(type: "INTEGER", nullable: true),
                    egreso_Imp_Ampliacion = table.Column<double>(type: "REAL", nullable: true),
                    Egreso_Imp_Reduccion = table.Column<double>(type: "REAL", nullable: true),
                    imp_Modificado = table.Column<double>(type: "REAL", nullable: true),
                    Egreso_Imp_Comprometido = table.Column<double>(type: "REAL", nullable: true),
                    Egreso_Imp_Devengado = table.Column<double>(type: "REAL", nullable: true),
                    Egreso_Imp_Ejercido = table.Column<double>(type: "REAL", nullable: true),
                    Egreso_Imp_Pagado = table.Column<double>(type: "REAL", nullable: true),
                    Ejecutado = table.Column<double>(type: "REAL", nullable: true),
                    Imp_Comp_Dev_Eje_Pagado = table.Column<double>(type: "REAL", nullable: true),
                    Cve_Rubro_Ingreso = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesPresupuesto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesIngreso");

            migrationBuilder.DropTable(
                name: "UnidadesPresupuesto");
        }
    }
}
