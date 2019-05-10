using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.TestTools
{
    [TestClass]
    public class StylistTest
    {

        //testclass constructor includes override address for test database
        public StylistTest()
        {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=dustin_herboldshimer_test;";
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            Stylist newStylist = new Stylist();
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

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
            Stylist newStylist = new Stylist("mike", "beard", 1);

            int result = newStylist.Id;
            Assert.AreEqual(id, result);
        }
    }
}