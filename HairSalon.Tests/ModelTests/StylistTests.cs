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
            Stylist newStylist = new Stylist("Mike", "Beard");
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }
    }
}