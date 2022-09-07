using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {

        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            // Com o mapeamento desta classe substituimos os DataAnnotations do Dominio
            builder.ToTable("Autor"); // informa tabela a ser utilizada

            // Com o mapeamento desta classe substituimos os DataAnnotations do Dominio
            builder.HasKey(x => x.Id); //Configura a propriedade chave primaria para esta entidade

            builder.Property(x => x.Nome).HasMaxLength(60).IsRequired(); // configura para propriedade Nome o tamanho 30 e tipo Requerido NotNull

            builder.HasMany(x => x.Livros) //Categoria tem muitos Livros para isso usar HasMany 
                .WithMany(x => x.Autores)
                .UsingEntity(x => x.ToTable("LivroAutor")); // Cria tabela associativa entre livro e autor
            // Basta fazer este mapeamento em uma das tabelas para criar, não é necessario criar na tabela Livro
        }
    }
}
