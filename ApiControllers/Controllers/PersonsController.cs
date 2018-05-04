using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiControllers.Controllers {

    [Route("api/[controller]")]
    public class PersonsController : Controller {
        private IRepository repository;

        public PersonsController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Person> Get() => repository.Persons;

        [HttpGet("{id}")]
        public Person Get(int id) => repository[id];

        [HttpPost]
        public Person Post([FromBody] Person res) =>
            repository.AddPerson(new Person {
                Name = res.Name,
                Post = res.Post,
                Phone = res.Phone
            });

        [HttpPut]
        public Person Put([FromBody] Person res) =>
            repository.UpdatePerson(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,
                [FromBody]JsonPatchDocument<Person> patch) {
            Person res = Get(id);
            if (res != null) {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeletePerson(id);
    }
}
