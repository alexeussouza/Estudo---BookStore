using BookStore.Domain;
using BookStore.Repositories;
using BookStore.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
      private IAuthorRepository repository;

        public AuthorController()
        {
            repository = new AuthorRepository();
        }
        
        [Route("listar")]
        public ActionResult Index()
        {
           var autores = repository.Get();
            
            return View(autores);
        }

        //******** Action Get
        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        //******** Action Post
        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Autor author)
        {
            if (repository.Create(author))
                return RedirectToAction("Index");
            return View(author);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int Id)
        {
            return View();
        }

        //******* Action Post
        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(Autor author)
        {
            if (repository.Update(author))
                return RedirectToAction("Index");
            return View(author);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int Id)
        {
            var author = repository.Get(Id);
            return View(author);
        }

        //*********** Action Post
        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        [Route("rota/{categoria:minlength(3)}")] // necessário digitar rota/abc  (rota/3  caracteres)
        public string flamengo(string texto)
        {

            return "OK! Cheguei na rota!";
        }

        [Route("rota4/{time:(flamengo)}")] // necessário digitar rota/abc  (rota/3  caracteres)
        public string MeuTime(string time)
        {

            return "OK! Seu time é " + time;
        }
    }
}
