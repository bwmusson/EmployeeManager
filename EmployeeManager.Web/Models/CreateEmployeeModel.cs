/** =========================================================

Ben Musson

Windows 10
Microsoft Visual Studio 2017 Enterprise

CIS 174
Week 5 User Story

Program Description: This program displays a form for creating an employee
record in a database, and then saves the record to the database.

Academic Honesty:
I attest that this is my original work.
I have not used unauthorized source code, either modified or unmodified.
I have not given other fellow student(s) access to my program.

=========================================================== **/
using EmployeeManager.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Web.Models
{
    public class CreateEmployeeModel
    {
        [Key]
        public Guid RecordGuid { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Pay Rate")]
        [DataType(DataType.Currency)]
        public decimal PayRate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Salary Type.")]
        [Display(Name = "Pay Type")]
        public PayType SalaryType { get; set; }
        [Required]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Available Hours")]
        public string AvailableHours { get; set; }
    }
}