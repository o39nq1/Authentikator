using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestExample.Test
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using UnitTestExample.Controllers;

    public class AccountControllerTestFixture
    {
        [Test,
            TestCase("abcd1234", false),
     TestCase("irf@uni-corvinus", false),
     TestCase("irf.uni-corvinus.hu", false),
     TestCase("irf@uni-corvinus.hu", true)]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            ClassicAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
