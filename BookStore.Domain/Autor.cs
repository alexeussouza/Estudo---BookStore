
namespace BookStore.Domain
{
    public class Autor
    {
	public Autor()
        {
            Livros = new List<Livro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; } // autor possui varios livros

    }
}
