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
                name: "Pacientes",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Pagos",
                columns: table => new
                {
                    pagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacienteId = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.pagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Pacientes_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "pacienteId",
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
                name: "Consultas",
                columns: table => new
                {
                    consultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicoId = table.Column<int>(type: "int", nullable: false),
                    importe = table.Column<double>(type: "float", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.consultaId);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "medicoId",
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

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    citaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultaId = table.Column<int>(type: "int", nullable: false),
                    pacienteId = table.Column<int>(type: "int", nullable: false),
                    inicio_cita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fin_cita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.citaId);
                    table.ForeignKey(
                        name: "FK_Citas_Consultas_consultaId",
                        column: x => x.consultaId,
                        principalTable: "Consultas",
                        principalColumn: "consultaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "pacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    horarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultaId = table.Column<int>(type: "int", nullable: false),
                    fecha_atencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    inicio_atencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fin_atencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    disponible = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.horarioId);
                    table.ForeignKey(
                        name: "FK_Horarios_Consultas_consultaId",
                        column: x => x.consultaId,
                        principalTable: "Consultas",
                        principalColumn: "consultaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    archivoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    citaId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    content_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tamano = table.Column<long>(type: "bigint", nullable: false),
                    extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.archivoId);
                    table.ForeignKey(
                        name: "FK_Archivos_Citas_citaId",
                        column: x => x.citaId,
                        principalTable: "Citas",
                        principalColumn: "citaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_citaId",
                table: "Archivos",
                column: "citaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_medicoId",
                table: "Calificaciones",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_pacienteId",
                table: "Calificaciones",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_consultaId",
                table: "Citas",
                column: "consultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_pacienteId",
                table: "Citas",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_medicoId",
                table: "Consultas",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_medicoId",
                table: "Estudios",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_medicoId",
                table: "Experiencias",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_consultaId",
                table: "Horarios",
                column: "consultaId");

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
                name: "IX_Pagos_pacienteId",
                table: "Pagos",
                column: "pacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Experiencias");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Residencias");

            migrationBuilder.DropTable(
                name: "SistemaOperativos");
        }
    }
}
