using System.Collections.Generic;

namespace ApiControllers.Models {

    public interface IRepository {

        IEnumerable<Person> Persons { get; }

        Person this[int id] { get; }

        Person AddPerson(Person person);

        Person UpdatePerson(Person person);

        void DeletePerson(int id);
    }
}
