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
    public class CupomMapping : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.VlCupom)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.ToTable("tb_Cupom");
        }
    }
}