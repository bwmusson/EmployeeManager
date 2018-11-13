using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManager.Test
{
    [TestClass]
    public class DateOfBirthServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 10, 31));
        }

        [TestMethod]
        public void BirthdayToday_ReturnsTrue_WhenBirthdayMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(1942, 10, 31));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var isBirthday = dateOfBirthService.IsTodayYourBirthday(employee);

            Assert.IsTrue(isBirthday);
        }

        [TestMethod]
        public void BirthdayNotToday_ReturnsFalse_WhenBirthdayDoesNotMatchToday()
        {
            var employee = CreateEmployee(new DateTime(1942, 3, 31));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var isBirthday = dateOfBirthService.IsTodayYourBirthday(employee);

            Assert.IsFalse(isBirthday);
        }


        private EmployeeViewModel CreateEmployee(DateTime dateOfBirth)
        {
            return new EmployeeViewModel()
            {
                RecordGuid = Guid.NewGuid(),
                FirstName = "Bob",
                BirthDate = dateOfBirth
            };
        }
    }
}
