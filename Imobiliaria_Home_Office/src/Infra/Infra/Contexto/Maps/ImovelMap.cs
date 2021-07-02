using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class ImovelMap : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.ToTable("imoveis");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(90).HasColumnType("varchar(90)");
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.QtdDeQuartos).IsRequired().HasColumnType("int");
            builder.Property(x => x.ValorDoAluguel).IsRequired().HasColumnType("decimal(10.2)");
        }
    }
}
