using BookStore.Domain;

namespace BookStore.Repositories.Contracts
{
    public interface IAuthorRepository : IDisposable
    //Criação de interface para o repositorio da entidade autor
    {
        List<Autor> Get();
        Autor Get(int id);
        Autor Get(string name);
        bool Create(Autor autor);
        bool Update(Autor autor);
        void Delete(int id);

    }
}
