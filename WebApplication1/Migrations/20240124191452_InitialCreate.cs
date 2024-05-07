using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CNPJEmpresa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelefoneEmpresa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnderecoEmpresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CidadeEmpresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UfEmpresa = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    PaisEmpresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CepEmpresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmailEmpresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtores",
                columns: table => new
                {
                    ProdutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProdutor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CpfProdutor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    RgProdutor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelefoneProdutor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnderecoProdutor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CidadeProdutor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UfProdutor = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    EmailProdutor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CepProdutor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtores", x => x.ProdutorId);
                });

            migrationBuilder.CreateTable(
                name: "Armazens",
                columns: table => new
                {
                    ArmazemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TelefoneArmazem = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnderecoArmazem = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CidadeArmazem = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UfArmazem = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    EmailArmazem = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armazens_1", x => x.ArmazemId);
                    table.ForeignKey(
                        name: "FK_Armazens_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propriedades",
                columns: table => new
                {
                    PropriedadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutorId = table.Column<int>(type: "int", nullable: false),
                    NomeFazenda = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CNPJFazenda = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    InscEstadual = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelefonePropriedade = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnderecoPropriedade = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CidadePropriedade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UfPropriedade = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    EmailPropriedade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CepPropriedade = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriedades", x => x.PropriedadeId);
                    table.ForeignKey(
                        name: "FK_Propriedades_Produtores",
                        column: x => x.ProdutorId,
                        principalTable: "Produtores",
                        principalColumn: "ProdutorId");
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutorId = table.Column<int>(type: "int", nullable: false),
                    PropriedadeId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ArmazemId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoLote = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    QtdSacas = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoLote = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CustoEntrada = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NfeEntrada = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    TipoEntrada = table.Column<int>(type: "int", nullable: true),
                    Safra = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TipoCafe = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LocalArmazenado = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EmbalagemArmazenado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_Entradas_Armazens",
                        column: x => x.ArmazemId,
                        principalTable: "Armazens",
                        principalColumn: "ArmazemId");
                    table.ForeignKey(
                        name: "FK_Entradas_Empresas",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId");
                    table.ForeignKey(
                        name: "FK_Entradas_Produtores",
                        column: x => x.ProdutorId,
                        principalTable: "Produtores",
                        principalColumn: "ProdutorId");
                    table.ForeignKey(
                        name: "FK_Entradas_Propriedades",
                        column: x => x.PropriedadeId,
                        principalTable: "Propriedades",
                        principalColumn: "PropriedadeId");
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    SaidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoProdutorId = table.Column<int>(type: "int", nullable: false),
                    DestinoPropriedadeId = table.Column<int>(type: "int", nullable: false),
                    DestinoEmpresaId = table.Column<int>(type: "int", nullable: false),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QtdSacas = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TipoSaida = table.Column<int>(type: "int", nullable: true),
                    PrecoSaida = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CustoSaida = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NfeSaida = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmbalagemSaida = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.SaidaId);
                    table.ForeignKey(
                        name: "FK_Saidas_Empresas",
                        column: x => x.DestinoEmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId");
                    table.ForeignKey(
                        name: "FK_Saidas_Entradas",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "EntradaId");
                    table.ForeignKey(
                        name: "FK_Saidas_Produtores",
                        column: x => x.DestinoProdutorId,
                        principalTable: "Produtores",
                        principalColumn: "ProdutorId");
                    table.ForeignKey(
                        name: "FK_Saidas_Propriedades",
                        column: x => x.DestinoPropriedadeId,
                        principalTable: "Propriedades",
                        principalColumn: "PropriedadeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armazens_EmpresaId",
                table: "Armazens",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ArmazemId",
                table: "Entradas",
                column: "ArmazemId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_EmpresaId",
                table: "Entradas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ProdutorId",
                table: "Entradas",
                column: "ProdutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_PropriedadeId",
                table: "Entradas",
                column: "PropriedadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Propriedades_ProdutorId",
                table: "Propriedades",
                column: "ProdutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_DestinoEmpresaId",
                table: "Saidas",
                column: "DestinoEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_DestinoProdutorId",
                table: "Saidas",
                column: "DestinoProdutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_DestinoPropriedadeId",
                table: "Saidas",
                column: "DestinoPropriedadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_EntradaId",
                table: "Saidas",
                column: "EntradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Armazens");

            migrationBuilder.DropTable(
                name: "Propriedades");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Produtores");
        }
    }
}
