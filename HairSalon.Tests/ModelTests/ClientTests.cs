using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.TestTools
{
    [TestClass]
    public class ClientTest : IDisposable
    {

        public void Dispose()
        {
            Client.ClearAllClients();
        }

        //testclass constructor includes override address for test database
        public ClientTest()
        {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=dustin_herboldshimer_test;";
        }

        //constructor tests
        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client(1);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        //property tests
        [TestMethod]
        public void GetPropertyFirstName_ReturnsFirstName_String()
        {
            string firstName = "Mike";
            Client newClient = new Client(1 , "Mike");

            string result = newClient.FirstName;
            Assert.AreEqual(firstName, result);
        }

        [TestMethod]
        public void GetPropertyLastName_ReturnsLastName_String()
        {
            string lastName = "beard";
            Client newClient = new Client(1,"mike", "beard");

            string result = newClient.LastName;
            Assert.AreEqual(lastName, result);
        }

        [TestMethod]
        public void GetPropertyId_ReturnsId_Int()
        {
            int id = 1;
            Client newClient = new Client(1,"mike", "beard");
            newClient.Id = id;
            int result = newClient.Id;
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetPropertyStylistId_ReturnsStylistId_Int()
        {
            int id = 2;
            Client newClient = new Client(2);
            newClient.Id = id;
            int result = newClient.StylistId;
            Assert.AreEqual(id, result);
        }

        //database tests
        [TestMethod]
        public void GetAll_ReturnsAllStylistsFromDataBase_List()
        {
            List<Client> clients = new List<Client>{};
            List<Client> result = Client.GetAll();
            CollectionAssert.AreEqual(clients, result);
        }

        //CreateStylist() is the 'save' method for client.  It returns
        //the primary id assigned to newClient.
        [TestMethod]
        public void CreateStylist_SavesStylistToDatabase_Stylist()
        {
            int stylist_id = 3;
            string firstName = "mike";
            string lastName = "beard";
            int testClient = Client.CreateClient(stylist_id, firstName, lastName);
            // Client.CreateClient(stylist_id, firstName, lastName);
            int result = Client.GetClient(testClient).Id;
            // List<Client> testList = new List<Client> {testClient};
            Assert.AreEqual(testClient, result);
        }

        public void GetClient_ReturnClientById_Client()
        {
            int newClientId = Client.CreateClient(1,"mike","beard");
            Client expected = new Client(1,"mike","beard");
            expected.Id = newClientId;
            Client result = Client.GetClient(newClientId);
            Assert.AreEqual(expected, result);
        }
    }
}