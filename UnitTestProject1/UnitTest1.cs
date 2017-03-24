using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVC1.Controllers;
using MVC1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController testController = new HomeController();

            //Act
            ViewResult result = testController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Home Page", result.ViewBag.Title);

        }
        [TestMethod]
        public void About()
        {
            //Arrange
            HomeController testController = new HomeController();

            //Act
            ViewResult result = testController.About() as ViewResult;

            //Assert
            var testModel = result.Model as AboutModel;
            Assert.AreEqual("someplace from localmodel", testModel.Location);
        }
        [TestMethod]
        public void Contact()
        {
            //Arrange
            HomeController testController = new HomeController();

            //Act
            ViewResult result = testController.Contact() as ViewResult;

            //Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }




    }
}
