﻿using LoanManagement;
using LoanManagement.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Tests.Controllers
{
    
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result != null);
            Assert.Equals("Home Page", result.ViewData.ToString());
        }
    }
}
