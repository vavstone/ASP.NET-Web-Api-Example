using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;

namespace ApiControllers.Controllers {

    public class HomeController : Controller {
        private IRepository repository { get; set; }

        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Persons);

        [HttpPost]
        public IActionResult AddPerson(Person person) {
            repository.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}
