using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Services;

namespace RazorPageTutorial.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository emplyeeRepository;
        public IEnumerable<Employee> Employees { get; set; }

        public IndexModel(IEmployeeRepository emplyeeRepository)
        {
            this.emplyeeRepository = emplyeeRepository;
        }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Employees = emplyeeRepository.Search(SearchTerm);
        }
    }
}