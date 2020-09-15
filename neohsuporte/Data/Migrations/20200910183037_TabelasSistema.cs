using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace neohsuporte.Data.Migrations
{
    public partial class TabelasSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HospitalId = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    CargoOcupacao = table.Column<string>(nullable: true),
                    SnAtivo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtenderPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    PedidoSuporte = table.Column<Guid>(nullable: false),
                    ObservacaoAtend = table.Column<string>(nullable: true),
                    DataConclusao = table.Column<DateTime>(nullable: false),
                    StatusPedido = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtenderPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtenderPedidos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CnpjHospital = table.Column<string>(nullable: false),
                    NmHospital = table.Column<string>(maxLength: 200, nullable: false),
                    HospitalGrupo = table.Column<bool>(nullable: false),
                    SnAtivo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    TipoSistema = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoSuportes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    HospitalId = table.Column<Guid>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    TipoChamado = table.Column<int>(nullable: false),
                    TituloChamado = table.Column<string>(maxLength: 200, nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    ObservacaoChamado = table.Column<string>(maxLength: 5000, nullable: false),
                    StatusPedido = table.Column<int>(nullable: false),
                    DataConclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSuportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoSuportes_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoSuportes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtenderPedidos_UsuarioId",
                table: "AtenderPedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_UsuarioId",
                table: "Hospitals",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSuportes_HospitalId",
                table: "PedidoSuportes",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSuportes_UsuarioId",
                table: "PedidoSuportes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtenderPedidos");

            migrationBuilder.DropTable(
                name: "PedidoSuportes");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
