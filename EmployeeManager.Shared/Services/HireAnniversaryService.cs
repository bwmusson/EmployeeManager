using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services
{
    public class HireAnniversaryService : IHireAnniversaryService
    {
        private readonly IDateTimeService _dateTimeService;

        public HireAnniversaryService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public bool IsTodayYourHireAnniversary(EmployeeViewModel employee)
        {
            return employee.HireDate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }
    }
}