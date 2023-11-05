using LoanManagement;
using LoanManagement.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;


namespace LoanManagement.Tests.Controllers
{
    
    public class ValuesControllerTest
    {
        [Test]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            //System.Web.Http.Results.JsonResult<IEnumerable<string>> jsonResult = controller.Get();
            //IEnumerable<string> result =  Json.Decode<IEnumerable<string>>(jsonResult.ToString());
            IEnumerable<string> result = controller.Get();            

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [Test]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [Test]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [Test]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [Test]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
