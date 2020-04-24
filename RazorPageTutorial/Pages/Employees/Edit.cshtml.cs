using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RazorPageTutorial.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile  Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

 
        public string Message { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = employeeRepository.GetEmployee(id);

            }
            else
            {
                Employee = new Employee();
            }


            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            { 
            
          
            if (Photo != null)
            {
                if (Employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", Employee.PhotoPath);
                    System.IO.File.Delete(filePath);

                }

                Employee.PhotoPath = ProcessUploadedFile();

            }

                if (Employee.Id > 0)
                {
                    Employee = employeeRepository.Update(Employee);

                }
                else
                {
                    Employee = employeeRepository.Add(Employee);
                }
                return RedirectToPage("Index");
            }

            return Page();

        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications.";
            }
            else
            {
                Message = "You have turned off email Notifications.";
            }
          //  TempData["Message"] = Message;

           // Employee = employeeRepository.GetEmployee(id);
            return RedirectToPage("Details", new { id = id});
        
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                string[] fileName = Photo.FileName.Split("\\");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName[fileName.Length - 1].ToString();
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

    }
}