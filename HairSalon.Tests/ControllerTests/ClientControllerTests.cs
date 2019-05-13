using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult indexView = controller.Index() as ActionResult;
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_ClientList()
        {
            ClientController controller = new ClientController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Client>));
        }

        [TestMethod]
        public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        {
            ClientController controller = new ClientController();
            IActionResult view = controller.Create(1, "mike", "beard");
            Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Create_RedirectsToCorrectAction_Index()
        {
            ClientController controller = new ClientController();
            RedirectToActionResult actionResult = controller.Create(1,"mike","beard") as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual(result, "Show");
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            IActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            int newStylistId = Stylist.CreateStylist("firstName","lastName");
            int id = Client.CreateClient(newStylistId ,"mike","beard");
            IActionResult showView = controller.Show(id);
            Assert.IsInstanceOfType(showView, typeof(ViewResult));
        }

        public void Show_HasCorrectModelType_Client()
        {
            ClientController controller = new ClientController();
            ViewResult showView = controller.Show(Client.CreateClient(1, "mike", "beard")) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Client));
        }

        public void Show_HasCorrectViewBagType_Client()
        {
            ClientController controller = new ClientController();
            int newStylistId = Stylist.CreateStylist("no", "name");
            int newClientId = Client.CreateClient(newStylistId, "mike","beard");
            Client newClient = Client.GetClient(newClientId);
            ViewResult showView = controller.Show(newClientId) as ViewResult;
            var result = showView.ViewData["Stylist"];
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }
    }
}