using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCperson.Models;

namespace MVCperson.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CurrentPersons currentPersons = new CurrentPersons();

            PeopleViewModel PersonListViewModel = new PeopleViewModel() { PersonsList = currentPersons.Populate() };

            if (PersonListViewModel.PersonsList.Count == 0 || PersonListViewModel.PersonsList == null)
            {
                currentPersons.PopulateDefaultList();
            }

            return View(PersonListViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {
            CurrentPersons currentPersons = new CurrentPersons();
            viewModel.PersonsList.Clear();
            foreach (Person p in currentPersons.Populate())
            {
                if ((p.Name.Contains(viewModel.SearchString, StringComparison.OrdinalIgnoreCase)) || (p.City.Contains(viewModel.SearchString, StringComparison.OrdinalIgnoreCase)))
                {
                    viewModel.PersonsList.Add(p);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddNewPerson(CreatePersonViewModel pPersonViewModel)
        {
            PeopleViewModel newViewModel = new PeopleViewModel();
            CurrentPersons currentPersons = new CurrentPersons();

            if (ModelState.IsValid)
            {
                newViewModel.Name = pPersonViewModel.Name;
                newViewModel.Phone = pPersonViewModel.Phone;
                newViewModel.City = pPersonViewModel.City;
                newViewModel.PersonsList = currentPersons.Populate();

                currentPersons.AddPerson(pPersonViewModel.Name, pPersonViewModel.Phone, pPersonViewModel.City);
            }
            return View("Index", newViewModel);
        }

        public IActionResult RemovePerson(int id)
        {
            CurrentPersons currentPersons = new CurrentPersons();
            Person targetPerson = currentPersons.Populate(id);
            currentPersons.Remove(targetPerson);

            return RedirectToAction("Index");
        }
    }
}
