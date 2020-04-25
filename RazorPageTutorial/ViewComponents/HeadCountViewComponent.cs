using Microsoft.AspNetCore.Mvc;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTutorial.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? departmentName=null)
        {
            var result = employeeRepository.EmployeeCountByDept(departmentName);
            return View(result);
        }
    }
}
