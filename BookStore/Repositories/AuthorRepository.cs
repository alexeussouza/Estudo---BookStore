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
            throw new NotImplementedException();
        }

        //Metodo Listar por Nome
        public Autor Get(string name)
        {
            throw new NotImplementedException();
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
            catch (Exception)
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
