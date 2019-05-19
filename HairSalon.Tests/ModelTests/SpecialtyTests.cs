using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.TestTools
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {

        public void Dispose()
        {
            Specialty.ClearSpecialties();
        }

        //testclass constructor includes override address for test database
        public SpecialtyTest()
        {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=dustin_herboldshimer_test;";
        }

        //constructor tests
        [TestMethod]
        public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("test");
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }

        [TestMethod]
        public void GetPropertyName_ReturnNameOfSpecialty_String()
        {
            string expected = "nails";
            Specialty newSpecialty = new Specialty("nails");

            string result = newSpecialty.Name;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPropertyId_ReturnsId_Int()
        {
            int id = 1;
            Specialty newSpecialty = new Specialty("test");
            newSpecialty.Id = id;
            int result = newSpecialty.Id;
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void CreateSpecialty_SavesSpecialtyToDatabase_Specialty()
        {
            int newSpeciatlyId = Specialty.CreateSpecialty("test");
            int result = Specialty.GetSpecialty(newSpeciatlyId).Id;
            Assert.AreEqual(newSpeciatlyId, result);
        }

        [TestMethod]
        public void GetSpecialty_ReturnSpecialtyById_Specialty()
        {
            int newSpecialtyId = Specialty.CreateSpecialty("test");
            Specialty expected = new Specialty("test");
            expected.Id = newSpecialtyId;
            Specialty result = Specialty.GetSpecialty(newSpecialtyId);
            Assert.AreEqual(expected, result);
        }

       public void GetAll_ReturnsAllSpecialtiesFromDataBase_List()
        {
            List<Specialty> specialties = new List<Specialty>{};
            List<Specialty> result = Specialty.GetAll();
            CollectionAssert.AreEqual(specialties, result);
        }

        // [TestMethod]
        // public void DeleteClient_RemoveClientFromDB_List()
        // {
        //     int newClientId = Client.CreateClient(1, "dummy", "client");
        //     List<Client> expected = new List<Client> {};

        //     Client client = Client.GetClient(newClientId);
        //     client.DeleteClient();

        //     CollectionAssert.AreEqual(expected, Client.GetAll());
        // }

        // [TestMethod]
        // public void ResetStylistId_SetClientStylistIdTo0_Int()
        // {
        //     int newClientId = Client.CreateClient(2, "dummy", "client");
        //     Client.GetClient(newClientId).ResetStylistId();
        //     Client newClient = Client.GetClient(newClientId);

        //     Assert.AreEqual(0, newClient.StylistId);
        // }

        // [TestMethod]
        // public void ResetAllByStylistId_ResetAllClientStylistIdsTo0_List()
        // {
        //     int newClientId1 = Client.CreateClient(1,"dummy","client1");
        //     int newClientId2 = Client.CreateClient(1,"dummy","client2");
        //     Client.ResetAllByStylistId(1);
        //     List<int> expected = new List<int> {0,0};
        //     List<int> result = new List<int> { Client.GetClient(newClientId1).StylistId, Client.GetClient(newClientId2).StylistId};

        //     CollectionAssert.AreEqual(expected, result);
        // }

        // [TestMethod]
        // public void EditClientInfo_UpdateClientInfo_String()
        // {
        //     int newClientId = Client.CreateClient(1,"dummy","client1");
        //     string firstName = "pam";
        //     string lastName = "whiskers";
        //     string phoneNumber = "5551239876";
        //     Client.GetClient(newClientId).EditClientInfo(firstName, lastName, phoneNumber);
        //     string expected = firstName + lastName + phoneNumber;
        //     string result = Client.GetClient(newClientId).FirstName + Client.GetClient(newClientId).LastName + Client.GetClient(newClientId).Phone;
        //     Assert.AreEqual(expected, result);
        // }
    }
}