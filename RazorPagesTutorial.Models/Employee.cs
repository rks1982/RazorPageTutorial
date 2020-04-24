using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesTutorial.Models
{
  public  class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required.")]
        [MinLength(3, ErrorMessage ="Name should contain at least 3 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage ="Invalid Email Address")] 
        [Display(Name="Email Address")]
        public string Email { get; set; }

        public string PhotoPath { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
