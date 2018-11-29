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
using EmployeeManager.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators.Interfaces
{
    public interface IEmployeeOrchestrator
    {
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<int> CreateEmployee(EmployeeViewModel employee);
        Task<bool> UpdateEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> SearchEmployee(string searchString);
        Task<EmployeeViewModel> GetEmployee(string id);
    }
}