using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Services;

namespace RazorPageTutorial.Pages.V2
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTutorial.Services.AddDbContext _context;

        public IndexModel(RazorPagesTutorial.Services.AddDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
