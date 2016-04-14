using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Paylocity.API.Models.Repository;
using Paylocity.API.Models.DTO;
using Paylocity.API.Controllers;
using System.Web.Http.Results;

namespace Paylocity.Tests
{
    [TestFixture]
    public class BenefitsAPI
    {
        [Test]
        public void BenefitsAPI_GetEmployee_ReturnsEmployee()
        {
            var employeeMock = new Mock<IEmployeeRepository>();

            employeeMock.Setup(service => service.GetEmployee(4)).Returns(new EmployeeDTO { Id = 4 });

            var beneController = new BenefitsController(employeeMock.Object);

            var value = beneController.GetEmployee(4) as OkNegotiatedContentResult<EmployeeDTO>;

            Assert.AreEqual(4, value.Content.Id);
        }

        [Test]
        public void BenefitsAPI_GetEmployee_ReturnsNotNull()
        {
            // arrange
            var employeeRepo = new Mock<IEmployeeRepository>();
            var dependentRepo = new Mock<IDependentRepository>();
            var benefitsRepo = new Mock<IBenefitRepository>();

            employeeRepo.Setup(e => e.GetEmployees()).Returns(new List<EmployeeDTO>());
            dependentRepo.Setup(d => d.GetDependentsByEmp(4)).Returns(new List<DependentDTO>());
            benefitsRepo.Setup(b => b.GetBenefit()).Returns(new BenefitDTO());

            // act
            var beneController = new BenefitsController(employeeRepo.Object, benefitsRepo.Object, dependentRepo.Object);

            // assert
            employeeRepo.Verify(e => e.GetEmployees(), Times.Exactly(1));
        }

    }
}
