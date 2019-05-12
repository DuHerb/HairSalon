using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult indexView = controller.Index() as ActionResult;
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_StylistList()
        {
            StylistController controller = new StylistController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        {
            StylistController controller = new StylistController();
            IActionResult view = controller.Create("mike","beard");
            Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Create_RedirectsToCorrectAction_Index()
        {
            StylistController controller = new StylistController();
            RedirectToActionResult actionResult = controller.Create("mike","beard") as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual(result, "Show");
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            IActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            int id = Stylist.CreateStylist("mike","beard");
            IActionResult showView = controller.Show(id);
            Assert.IsInstanceOfType(showView, typeof(ViewResult));
        }

        public void Show_HasCorrectModelType_Stylist()
        {
            StylistController controller = new StylistController();
            ViewResult showView = controller.Show(Stylist.CreateStylist("mike", "beard")) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }
    }
}