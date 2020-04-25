using RazorPagesTutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RazorPagesTutorial.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
            new Employee() { Id=1, Name="Michku Singh", Department = Dept.HR,PhotoPath="Michku.jpg", Email= "Michku@ctc.com" },
            new Employee() { Id=2, Name="Guru Nayak", Department = Dept.HR, PhotoPath="Guru.jpg", Email= "Guru@ctc.com",  },
            new Employee() { Id=3, Name="Sachala Singh", Department = Dept.IT, PhotoPath="Guru.jpg", Email= "Sachala@ctc.com" },
            new Employee() { Id=4, Name="Ranjeet Singh", Department = Dept.IT, PhotoPath="Michku.jpg", Email= "Ranjeet@ctc.com" }

            };


        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
           Employee employeeToDelete = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                _employeeList.Remove(employeeToDelete);
            }
            return employeeToDelete;

        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);

            }

            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount() { Department = g.Key.Value, Count = g.Count() }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int? id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _employeeList;
            }
            return _employeeList.Where(e => e.Name.Contains(search) || e.Email.Contains(search));

        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee= _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;

        }
    }
}
