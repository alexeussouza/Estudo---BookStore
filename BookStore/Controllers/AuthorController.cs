using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        [Route("listar")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int Id)
        {
            return View();
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int Id)
        {
            return View();
        }
    }
}
