using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCperson.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<Person> PersonsList { get; set; } = new List<Person>();
        public string SearchString { get; set; }
        public PeopleViewModel()
        {
            PersonsList = new List<Person>();
        }
    }
}
