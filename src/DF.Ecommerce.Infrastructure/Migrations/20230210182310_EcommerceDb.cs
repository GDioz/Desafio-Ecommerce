using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DF.Ecommerce.Infrastructure.Migrations
{
    public partial class EcommerceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Cupom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    VlCupom = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Cupom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Carrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCupom = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Carrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Carrinho_tb_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "tb_Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Carrinho_tb_Cupom_IdCupom",
                        column: x => x.IdCupom,
                        principalTable: "tb_Cupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_ItemCarrinho",
                columns: table => new
                {
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCarrinho = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ItemCarrinho", x => new { x.IdCarrinho, x.IdProduto });
                    table.ForeignKey(
                        name: "FK_tb_ItemCarrinho_tb_Carrinho_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "tb_Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_ItemCarrinho_tb_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "tb_Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Carrinho_IdCliente",
                table: "tb_Carrinho",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Carrinho_IdCupom",
                table: "tb_Carrinho",
                column: "IdCupom");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ItemCarrinho_IdProduto",
                table: "tb_ItemCarrinho",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ItemCarrinho");

            migrationBuilder.DropTable(
                name: "tb_Carrinho");

            migrationBuilder.DropTable(
                name: "tb_Produto");

            migrationBuilder.DropTable(
                name: "tb_Cliente");

            migrationBuilder.DropTable(
                name: "tb_Cupom");
        }
    }
}
