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

using EmployeeManager.Domain;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManager.Shared.Orchestrators
{
    public class EmployeeOrchestrator : IEmployeeOrchestrator
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeOrchestrator()
        {
            _employeeContext = new EmployeeContext();
        }
        
        public async Task<int> CreateEmployee(EmployeeViewModel employee)
        {
            _employeeContext.Employees.Add(new Employee
            {
                RecordGuid = employee.RecordGuid,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                PayRate = employee.PayRate,
                SalaryType = employee.SalaryType,
                EmployeeId = employee.EmployeeId,
                AvailableHours = employee.AvailableHours
            });

            return await _employeeContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeContext.Employees.Select(x => new EmployeeViewModel()
            {
                RecordGuid = x.RecordGuid,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Department = x.Department,
                JobTitle = x.JobTitle,
                PayRate = x.PayRate,
                SalaryTypeString = x.SalaryTypeString,
                EmployeeId = x.EmployeeId,
                AvailableHours = x.AvailableHours
            }).ToListAsync();

            return employees;
        }

        public async Task<EmployeeViewModel> SearchEmployee(string searchString)
        {
            var employee = await _employeeContext.Employees
                .Where(x => x.FirstName.Contains(searchString) 
                            || x.MiddleName.Contains(searchString)
                            || x.LastName.Contains(searchString)
                            || x.EmployeeId.Contains(searchString))
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                return new EmployeeViewModel();
            }

            var viewModel = new EmployeeViewModel
            {
                RecordGuid = employee.RecordGuid,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate.Date,
                HireDate = employee.HireDate.Date,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                PayRate = employee.PayRate,
                SalaryType = employee.SalaryType,
                EmployeeId = employee.EmployeeId,
                AvailableHours = employee.AvailableHours
            };

            return viewModel;
        }

        public async Task<bool> UpdateEmployee(EmployeeViewModel employee)
        {
            var updateEntity = await _employeeContext.Employees.FindAsync(employee.RecordGuid);

            if (updateEntity == null)
            {
                return false;
            }

            updateEntity.FirstName = employee.FirstName;
            updateEntity.MiddleName = employee.MiddleName;
            updateEntity.LastName = employee.LastName;
            updateEntity.BirthDate = employee.BirthDate;
            updateEntity.HireDate = employee.HireDate;
            updateEntity.Department = employee.Department;
            updateEntity.JobTitle = employee.JobTitle;
            updateEntity.PayRate = employee.PayRate;
            updateEntity.SalaryType = employee.SalaryType;
            updateEntity.EmployeeId = employee.EmployeeId;
            updateEntity.AvailableHours = employee.AvailableHours;

            await _employeeContext.SaveChangesAsync();

            return true;
        }
    }
}