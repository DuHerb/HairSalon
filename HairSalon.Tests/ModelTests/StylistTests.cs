using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.TestTools
{
    [TestClass]
    public class StylistTest : IDisposable
    {

        public void Dispose()
        {
            Stylist.ClearAllStylists();
        }

        //testclass constructor includes override address for test database
        public StylistTest()
        {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=dustin_herboldshimer_test;";
        }

        //constructor tests
        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            Stylist newStylist = new Stylist();
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        //property tests
        [TestMethod]
        public void GetPropertyFirstName_ReturnsFirstName_String()
        {
            string firstName = "Mike";
            Stylist newStylist = new Stylist("Mike");

            string result = newStylist.FirstName;
            Assert.AreEqual(firstName, result);
        }

        [TestMethod]
        public void GetPropertyLastName_ReturnsLastName_String()
        {
            string lastName = "beard";
            Stylist newStylist = new Stylist("mike", "beard");

            string result = newStylist.LastName;
            Assert.AreEqual(lastName, result);
        }

        [TestMethod]
        public void GetPropertyId_ReturnsId_Int()
        {
            int id = 1;
            Stylist newStylist = new Stylist("mike", "beard");
            newStylist.Id = id;
            int result = newStylist.Id;
            Assert.AreEqual(id, result);
        }

        //database tests
        [TestMethod]
        public void GetAll_ReturnsAllStylistsFromDataBase_List()
        {
            List<Stylist> stylists = new List<Stylist>{};
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(stylists, result);
        }
        [TestMethod]
        public void CreateStylist_SavesStylistToDatabase_Stylist()
        {
            string firstName = "mike";
            string lastName = "beard";
            Stylist testStylist = new Stylist();
            int stylistId = Stylist.CreateStylist(firstName, lastName);
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist> {Stylist.GetStylist(stylistId)};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void DeleteStylist_RemoveStylistFromDataBase_True()
        {
            int newStylistId = Stylist.CreateStylist("mike","beard");
            List<Stylist> expected = new List<Stylist>{};
            Stylist.GetStylist(newStylistId).DeleteStylist();
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EditName_ChangeStylistsName_Void()
        {
            int newStylistId = Stylist.CreateStylist("mike","beard");
            string newFirstName = "pam";
            string newLastName = "whiskers";
            Stylist.GetStylist(newStylistId).EditName(newFirstName, newLastName);
            string expected = newFirstName + newLastName;
            string result = Stylist.GetStylist(newStylistId).FirstName + Stylist.GetStylist(newStylistId).LastName;
            Assert.AreEqual(expected,result);
        }
    }
}