using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManager.Test
{
    [TestClass]
    public class FullYearServiceTests
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
        public void ThreeYearsEmployed_ReturnsTrue_WhenHireDateIsThreeYearsAgo()
        {
            var employee = CreateEmployee(new DateTime(1974, 12, 31), new DateTime(2015, 10, 31));

            var fullYearService = _mocker.Create<FullYearService>();

            var yearsEmployed = fullYearService.HowManyYearsEmployed(employee);

            Assert.IsTrue(yearsEmployed == 3);
        }

        [TestMethod]
        public void FiveYearsEmployed_ReturnsTrue_WhenHireDateIsFiveYearsAgo()
        {
            var employee = CreateEmployee(new DateTime(1974, 12, 31), new DateTime(2013, 10, 31));

            var fullYearService = _mocker.Create<FullYearService>();

            var yearsEmployed = fullYearService.HowManyYearsEmployed(employee);

            Assert.IsTrue(yearsEmployed == 5);
        }

        [TestMethod]
        public void NotFiveYearsEmployed_ReturnsFalse_WhenHireDateIsNotFiveYearsAgo()
        {
            var employee = CreateEmployee(new DateTime(1974, 12, 31), new DateTime(2012, 10, 31));

            var fullYearService = _mocker.Create<FullYearService>();

            var yearsEmployed = fullYearService.HowManyYearsEmployed(employee);

            Assert.IsFalse(yearsEmployed == 5);
        }

        [TestMethod]
        public void FiftyYearsOld_ReturnsTrue_WhenBirthDateIsFiftyYearsAgo()
        {
            var employee = CreateEmployee(new DateTime(1968, 10, 31), new DateTime(2015, 10, 31));

            var fullYearService = _mocker.Create<FullYearService>();

            var age = fullYearService.HowManyYearsOld(employee);

            Assert.IsTrue(age == 50);
        }

        [TestMethod]
        public void NotFiftyYearsOld_ReturnsFalse_WhenBirthDateIsNotQuiteFiftyYearsAgo()
        {
            var employee = CreateEmployee(new DateTime(1968, 11, 1), new DateTime(2015, 10, 31));

            var fullYearService = _mocker.Create<FullYearService>();

            var age = fullYearService.HowManyYearsOld(employee);

            Assert.IsFalse(age == 50);
        }

        private EmployeeViewModel CreateEmployee(DateTime dateOfBirth, DateTime dateOfHire)
        {
            return new EmployeeViewModel()
            {
                RecordGuid = Guid.NewGuid(),
                FirstName = "Bob",
                BirthDate = dateOfBirth,
                HireDate = dateOfHire
            };
        }
    }
}
