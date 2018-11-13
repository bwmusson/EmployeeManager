using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services
{
    public class DateOfBirthService : IDateOfBirthService
    {
        private readonly IDateTimeService _dateTimeService;

        public DateOfBirthService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public bool IsTodayYourBirthday(EmployeeViewModel employee)
        {
            return employee.BirthDate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }
    }
}