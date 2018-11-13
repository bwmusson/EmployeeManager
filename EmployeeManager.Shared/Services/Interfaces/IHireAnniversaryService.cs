using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IHireAnniversaryService
    {
        bool IsTodayYourHireAnniversary(EmployeeViewModel employee);
    }
}