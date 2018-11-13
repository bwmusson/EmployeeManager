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

namespace EmployeeManager.Api.Models
{
    public class EmployeeModel
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public string department { get; set; }
        public string jobTitle { get; set; }
        public decimal payRate { get; set; }
        public PayType payType { get; set; }
        public Guid employeeID { get; set; }
        public string availableHours { get; set; }
    }
}