using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    { 
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            // Com o mapeamento desta classe substituimos os DataAnnotations do Dominio
            builder.ToTable("Livro"); // informa tabela a ser utilizada

            builder.HasKey(x => x.Id); //Configura a propriedade chave primaria para esta entidade

            builder.Property(x => x.Nome).HasMaxLength(60).IsRequired(); // configura para propriedade Nome o tamanho 30 e tipo Requerido NotNull
            builder.Property(x => x.ISBN).HasMaxLength(30).IsRequired();
            builder.Property(x => x.DataLancamento).IsRequired();
        }
    }
}
