using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System;

namespace EmployeeManager.Shared.Services
{
    public class FullYearService : IFullYearService
    {
        private readonly IDateTimeService _dateTimeService;

        public FullYearService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public int HowManyYearsEmployed(EmployeeViewModel employee)
        {   
            int years = _dateTimeService.Now().Year - employee.HireDate.Year;

            if (_dateTimeService.Now().Month < employee.HireDate.Month 
                || (_dateTimeService.Now().Month == employee.HireDate.Month && _dateTimeService.Now().Day < employee.HireDate.Day))
                years--;

            return years;
        }
        public int HowManyYearsOld(EmployeeViewModel employee)
        {
            int age = _dateTimeService.Now().Year - employee.BirthDate.Year;

            if (_dateTimeService.Now().Month < employee.BirthDate.Month 
                || (_dateTimeService.Now().Month == employee.BirthDate.Month && _dateTimeService.Now().Day < employee.BirthDate.Day))
                age--;

            return age;
        }
    }
}