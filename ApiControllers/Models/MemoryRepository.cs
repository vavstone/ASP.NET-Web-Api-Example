using System.Collections.Generic;

namespace ApiControllers.Models {

    public class MemoryRepository : IRepository {

        private Dictionary<int, Person> items = new Dictionary<int, Person>();

        public Person this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Person> Persons => items.Values;

        public Person AddPerson(Person person) {
            if (person.PersonId == 0) {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                person.PersonId = key;
            }
            items[person.PersonId] = person;
            return person;
        }

        public void DeletePerson(int id) => items.Remove(id);

        public Person UpdatePerson(Person person)
        {
            items[person.PersonId] = person;
            return person;
        }

    }
}
