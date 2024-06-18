using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace porn_prueba.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__D2D146375050996A", x => x.id_user);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
