using EmployeeManager.Api.Models;
using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace EmployeeManager.Api.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeOrchestrator _employeeOrchestrator = new EmployeeOrchestrator();

        public EmployeesController()
        {
            _employeeOrchestrator = new EmployeeOrchestrator();
        }

        // GET: api/Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<EmployeeViewModel> employeeList = await _employeeOrchestrator.GetAllEmployees();

            List<Employee> empList = new List<Employee>();

            foreach (EmployeeViewModel emp in employeeList)
            {
                Employee e = new Employee();

                e.FullName = emp.FirstName + " " + emp.MiddleName + " " + emp.LastName;
                e.EmployeeId = emp.EmployeeId;

                empList.Add(e);
            }

            return empList; 
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> GetSingleEmployee(string id)
        {
            id = id.Trim();
            var viewModel = await _employeeOrchestrator.SearchEmployee(id);
            
            if (viewModel.RecordGuid == Guid.Empty)
            {
                return Content(HttpStatusCode.NotFound, "Error 404: Employee Id Not Found");
            }

            else
            {
                EmployeeDetail emp = new EmployeeDetail();
                emp.FirstName = viewModel.FirstName;
                emp.MiddleName = viewModel.MiddleName;
                emp.LastName = viewModel.LastName;
                emp.BirthDate = viewModel.BirthDate.ToShortDateString();
                emp.Department = viewModel.Department;
                
                return Ok(emp);
            }

        }

    }
}
