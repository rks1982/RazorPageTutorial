﻿using RazorPagesTutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesTutorial.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace RazorPagesTutorial.Services
{
   public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AddDbContext context;

        public SQLEmployeeRepository(AddDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            //context.Employees.Add(newEmployee);
            //context.SaveChanges();
            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}", newEmployee.Name, newEmployee.Email, newEmployee.PhotoPath, newEmployee.Department);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {

            IEnumerable<Employee> query = context.Employees;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);

            }

            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount() { Department = g.Key.Value, Count = g.Count() }).ToList();



        }

        public IEnumerable<Employee> GetAllEmployees()
        {


            return context.Employees.FromSqlRaw<Employee>("SELECT * FROM Employees").ToList();
        }

        public Employee GetEmployee(int? id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Employees.FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter).ToList().FirstOrDefault();
            
        }

        public IEnumerable<Employee> Search(string search)
        {
           
            if (string.IsNullOrEmpty(search))
            {
                return context.Employees;
            }
            return context.Employees.Where(e => e.Name.Contains(search) || e.Email.Contains(search));

        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedEmployee;
        }
    }
}
