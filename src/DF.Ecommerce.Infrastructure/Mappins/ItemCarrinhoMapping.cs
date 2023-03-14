using DF.Ecommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Mappins
{
    public class ItemCarrinhoMapping : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(x => new { x.IdCarrinho, x.IdProduto });

            builder.Property( x => x.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ItensCarrinhos)
                .HasForeignKey(x => x.IdProduto);

            builder.HasOne(x => x.Carrinho)
                .WithMany(x => x.ItemCarrinhos)
                .HasForeignKey(x => x.IdCarrinho);

            builder.ToTable("tb_ItemCarrinho");

        }
    }
}
