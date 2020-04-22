﻿using RazorPagesTutorial.Models;
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
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee= _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
            }

            return employee;

        }
    }
}