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
    public class ClienteMaping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(x => x.Carrinho)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Carrinho>(x => x.IdCliente);

            builder.ToTable("tb_Cliente");
        }
    }
}
