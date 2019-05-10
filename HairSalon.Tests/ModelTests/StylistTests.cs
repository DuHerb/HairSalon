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
            Stylist.ClearAll();
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
            Stylist newStylist = new Stylist(1, "Mike");

            string result = newStylist.FirstName;
            Assert.AreEqual(firstName, result);
        }

        [TestMethod]
        public void GetPropertyLastName_ReturnsLastName_String()
        {
            string lastName = "beard";
            Stylist newStylist = new Stylist(1, "mike", "beard");

            string result = newStylist.LastName;
            Assert.AreEqual(lastName, result);
        }

        [TestMethod]
        public void GetPropertyId_ReturnsId_Int()
        {
            int id = 1;
            Stylist newStylist = new Stylist(id, "mike", "beard");

            int result = newStylist.Id;
            Assert.AreEqual(id, result);
        }

        //database tests
        [TestMethod]
        public void GetAll_ReturnsAllStylistsFromDataBase_List()
        {
            List<Stylist> stylists = new List<Stylist>{};
            // Stylist newStylist = new Stylist();
            // string result = newStylist.FirstName;
            // string expected = "default";
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(stylists, result);
        }
        // // [TestMethod]
        // public void Save_SavesStylistToDatabase_Stylist()
        // {

        // }
    }
}