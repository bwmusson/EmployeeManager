using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IDateOfBirthService
    {
        bool IsTodayYourBirthday(EmployeeViewModel employee);
    }
}