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
using EmployeeManager.Shared.Orchestrators;
using System.Web.Http;

namespace EmployeeManager.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController()
        {
            _employeeOrchestrator = new EmployeeOrchestrator();
        }
    }
}
