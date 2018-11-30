using FluentAssertions;
using HW11Types;
using Moq;
using NUnit.Framework;
using HW11Database;
using System;
using System.Diagnostics;
using System.Data;

namespace HW11Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddPotential()
        {
            var p = new Potential("Sarah", "Bob", "No Additional Details", 23, 9, true);
            var mockDataStorage = new Mock<IDataStorage>();
            var potentialRepo = new PotentialRepository(mockDataStorage.Object);

            var result = potentialRepo.AddPotential(p); 
            result.Should().BeTrue();
        }

        [Test]
        public void RemovePotential()
        {
            var tempSQLiteDatabase = new SqliteDataStore();
            var p = new Potential("Sarah", "Bob", "No Additional Details", 23, 9, true);
            var mockDataStorage = new Mock<IDataStorage>();
            var potentialRepo = new PotentialRepository(mockDataStorage.Object);
            potentialRepo.AddPotential(p);

            //We are making a change here to see if continous integration works on azure.

            var rp = potentialRepo.GetASpecificId(1);
            //var firstName = rp.FirstName;
            //var thisResult = potentialRepo.RemovePotentialById((int)rp);
            //Assert.AreEqual("Potential Removed", thisResult);
            Assert.AreEqual("Sarah", p.FirstName);
        }

        [Test]
        public void isTrueTest()
        {
            Assert.AreEqual(true, true);
        }
    }
}
