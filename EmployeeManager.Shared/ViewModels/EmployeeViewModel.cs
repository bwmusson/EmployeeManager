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

namespace EmployeeManager.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        private PayType salaryType;
        [Key] public Guid RecordGuid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public decimal PayRate { get; set; }
        public PayType SalaryType {
            get { return this.salaryType; }
            set { this.salaryType = value; }
        }
        public string SalaryTypeString
        {
            get { return this.salaryType.ToString();}
            set
            {
                var st = Enum.Parse(typeof(PayType), value);
                this.salaryType = (PayType) st;
            }
        }
        public string EmployeeId { get; set; }
        public string AvailableHours { get; set; }
    }
}