using EmployeeManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IFullYearService
    {
        int HowManyYearsEmployed(EmployeeViewModel employee);
        int HowManyYearsOld(EmployeeViewModel employee);
    }
}