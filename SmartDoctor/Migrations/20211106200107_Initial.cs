using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDoctor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    especialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.especialidadId);
                });

            migrationBuilder.CreateTable(
                name: "Parentescos",
                columns: table => new
                {
                    parentescoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentescos", x => x.parentescoId);
                });

            migrationBuilder.CreateTable(
                name: "Residencias",
                columns: table => new
                {
                    residenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residencias", x => x.residenciaId);
                });

            migrationBuilder.CreateTable(
                name: "SistemaOperativos",
                columns: table => new
                {
                    sistemaOperativoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaOperativos", x => x.sistemaOperativoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentescoId = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    sexo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    distrito_colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.pacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Parentescos_parentescoId",
                        column: x => x.parentescoId,
                        principalTable: "Parentescos",
                        principalColumn: "parentescoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    medicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    especialidadId = table.Column<int>(type: "int", nullable: false),
                    residenciaId = table.Column<int>(type: "int", nullable: false),
                    sistemaOperativoId = table.Column<int>(type: "int", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.medicoId);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_especialidadId",
                        column: x => x.especialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "especialidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_Residencias_residenciaId",
                        column: x => x.residenciaId,
                        principalTable: "Residencias",
                        principalColumn: "residenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_SistemaOperativos_sistemaOperativoId",
                        column: x => x.sistemaOperativoId,
                        principalTable: "SistemaOperativos",
                        principalColumn: "sistemaOperativoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    calificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicoId = table.Column<int>(type: "int", nullable: false),
                    pacienteId = table.Column<int>(type: "int", nullable: false),
                    puntuacion = table.Column<double>(type: "float", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.calificacionId);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "medicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Pacientes_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "pacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    estudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    medicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.estudioId);
                    table.ForeignKey(
                        name: "FK_Estudios_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "medicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiencias",
                columns: table => new
                {
                    experienciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    medicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencias", x => x.experienciaId);
                    table.ForeignKey(
                        name: "FK_Experiencias_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "medicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_medicoId",
                table: "Calificaciones",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_pacienteId",
                table: "Calificaciones",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_medicoId",
                table: "Estudios",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_medicoId",
                table: "Experiencias",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_especialidadId",
                table: "Medicos",
                column: "especialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_residenciaId",
                table: "Medicos",
                column: "residenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_sistemaOperativoId",
                table: "Medicos",
                column: "sistemaOperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_parentescoId",
                table: "Pacientes",
                column: "parentescoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Experiencias");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Parentescos");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Residencias");

            migrationBuilder.DropTable(
                name: "SistemaOperativos");
        }
    }
}
