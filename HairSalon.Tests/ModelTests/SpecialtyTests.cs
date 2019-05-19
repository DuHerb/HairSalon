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
    }
}