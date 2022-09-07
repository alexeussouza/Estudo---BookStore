using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Tabela
            builder.ToTable("Categoria");
            
            //Identity
            builder.HasKey(x => x.Id); //Configura a propriedade chave primaria para esta entidade

            //Propriedades
            builder.Property(x => x.Nome).HasMaxLength(30).IsRequired(); // configura para propriedade Nome o tamanho 30 e tipo Requerido NotNull

            builder.HasMany(x => x.Livros) //Categoria tem muitos Livros para isso usar HasMany 
                . WithOne(x => x.Categoria).IsRequired(); // Livro possui uma Categoria que é requerida WithRequired.
        }
    }
}
