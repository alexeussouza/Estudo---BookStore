using BookStore.Context;
using BookStore.Domain;
using BookStore.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        private BookStoreDataContext _db;

        public AuthorRepository(BookStoreDataContext db) // injeção de dependencia para ter acesso ao BookStoreDataContext
        {
            _db = db;   
        }

        public AuthorRepository()
        {
        }

        //Metodo Criar
        public bool Create(Autor autor)
        {
            try
            {
                _db.Autores.Add(autor);
                _db.SaveChanges();  
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Metodo Deletar
        public void Delete(int id)
        {
            var autor = _db.Autores.Find(id); // procura autor pelo id usando o Find
            _db.Autores.Remove(autor);
            _db.SaveChanges();
        }

        //Metodo Listar
        public List<Autor> Get()
        {
            return _db.Autores.ToList();
        }

        //Metodo Listar por Id
        public Autor Get(int id)
        {
            return _db.Autores.Find(id);
        }

        //Metodo Listar por Nome
        public List <Autor> GetByName(string name) 
        {
            return _db.Autores
                .Where(x => x.Nome.Contains(name))
                .ToList(); // retorna uma lista usando SQL Like em Nomes com a variavel name
        }

        //Metodo Atualizar
        public bool Update(Autor autor)
        {
            try
            {
                _db.Entry<Autor>(autor).State = EntityState.Modified; 
                // busca autor no banco, caso a informação recebida seja diferente o EF atualiza os dados
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        //Metodo Dispose
        public void Dispose()
        {
            _db.Dispose();

        }
    }
}
