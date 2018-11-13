using EmployeeManager.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Web.Models
{
    public class UpdateEmployeeModel
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
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Available Hours")]
        public string AvailableHours { get; set; }
    }
}