using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCperson.Models
{
    public class CurrentPersons
    {
        private static readonly List<Person> _personList = new List<Person>();
        private static int _idCounter; 
        public void PopulateDefaultList()
        {
            CurrentPersons currentPersons = new CurrentPersons();
            currentPersons.AddPerson("Duke Nukem", "555-69", "Shrapnel City");
            currentPersons.AddPerson("Illidan Stormrage", "555-666", "Black Temple");
            currentPersons.AddPerson("Doomguy", "555-1337", "<unknown>");
        }

        public Person AddPerson(string name, string phone, string city)
        {
            Person newPerson = new Person(_idCounter, name, phone, city);
            _personList.Add(newPerson);
            _idCounter++;
            return newPerson;
        } 

        public List<Person> Populate()
        {
            return _personList;
        }

        public Person Populate(int id)
        {
            Person targetPerson = _personList.Find(p => p.PersonId == id);
            return targetPerson;
        }

        public bool Remove(Person person)
        {
            bool liststatus = _personList.Remove(person);
            return liststatus;
        }
    }
}
