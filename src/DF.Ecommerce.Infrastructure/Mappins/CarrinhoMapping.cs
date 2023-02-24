using DF.Ecommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Mappins
{
    public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.VlTotal)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
            
            builder.HasOne(x => x.Cupom)
                .WithMany(x => x.Carrinhos)
                .HasForeignKey(x => x.IdCupom)
                .IsRequired(false);



            builder.ToTable("tb_Carrinho");
        }
    }
}
