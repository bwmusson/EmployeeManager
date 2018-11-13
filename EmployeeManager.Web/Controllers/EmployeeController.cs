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
using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using EmployeeManager.Web.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController(IEmployeeOrchestrator employeeOrchestrator)
        {
            _employeeOrchestrator = employeeOrchestrator;
        }

        public ActionResult CreateEmployee()
        {
            if (Request.IsAuthenticated)
            {
                return View("CreateEmployee");
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        public async Task<ActionResult> AllEmployees()
        {
            if (Request.IsAuthenticated)
            {
                var employeeDisplayModel = new EmployeeDisplayModel()
                {
                    Employees = await _employeeOrchestrator.GetAllEmployees()
                };
                return View(employeeDisplayModel);
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        public async Task<ActionResult> EmployeeAnniversaries()
        {
            if (Request.IsAuthenticated)
            {
                var employeeDisplayModel = new EmployeeDisplayModel()
                {
                    Employees = await _employeeOrchestrator.GetAllEmployees()
                };
                return View(employeeDisplayModel);
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeOrchestrator.CreateEmployee(new EmployeeViewModel
                    {
                        RecordGuid = Guid.NewGuid(),
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
                    });
                    System.Web.HttpContext.Current.Response.Write("<script>alert('Employee record created successfully.')</script>");
                    ModelState.Clear();
                    return View("CreateEmployee");
                }
                catch (DataException dex)
                {
                    Console.WriteLine(dex);
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View("CreateEmployee");
        }

        public ActionResult UpdateEmployee()
        {
            if (Request.IsAuthenticated)
            {
                return View("UpdateEmployee");
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        [HttpGet]
        public async Task<JsonResult> Update(UpdateEmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeOrchestrator.UpdateEmployee(new EmployeeViewModel
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

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (employee.RecordGuid == Guid.Empty)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Search(string searchString)
        {
            searchString = searchString.Trim();
            var viewModel = await _employeeOrchestrator.SearchEmployee(searchString);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}