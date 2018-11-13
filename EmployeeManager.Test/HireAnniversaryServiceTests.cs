using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManager.Test
{
    [TestClass]
    public class HireAnniversaryServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 4, 18));
        }

        [TestMethod]
        public void AnniversaryToday_ReturnsTrue_WhenHireDateMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(2011, 4, 18));

            var hireAnniversaryService = _mocker.Create<HireAnniversaryService>();

            var isBirthday = hireAnniversaryService.IsTodayYourHireAnniversary(employee);

            Assert.IsTrue(isBirthday);
        }

        [TestMethod]
        public void AnniversaryNotToday_ReturnsFalse_WhenHireDateDoesNotMatchToday()
        {
            var employee = CreateEmployee(new DateTime(2011, 6, 12));

            var hireAnniversaryService = _mocker.Create<HireAnniversaryService>();

            var isBirthday = hireAnniversaryService.IsTodayYourHireAnniversary(employee);

            Assert.IsFalse(isBirthday);
        }


        private EmployeeViewModel CreateEmployee(DateTime dateOfHire)
        {
            return new EmployeeViewModel()
            {
                RecordGuid = Guid.NewGuid(),
                FirstName = "Bob",
                HireDate = dateOfHire
            };
        }
    }
}
