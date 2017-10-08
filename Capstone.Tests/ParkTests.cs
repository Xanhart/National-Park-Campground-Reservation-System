using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkTests
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NationalParks;User ID=te_student;Password=sqlserver1";
        TransactionScope t;

        [TestInitialize]
        public void Initialize()
        {
          
            t = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
          
            t.Dispose();
        }
        [TestMethod]
        public void TestToSeeIfGetAllParksWorks()
        {
            // Create a fake park
            Park p = new Park();
            p.Name = "Blerg";
            p.Location = "Blergastan";
            p.Establish_date = DateTime.Now;
            p.Area = 54321;
            p.Visitors = 2;
            p.Description = "A place where no one knows your name";

            ParkSQLDAL dal = new ParkSQLDAL(connectionString);
            List<Park> d = dal.ShowAllNationalParks();
            bool output = (d.Count > 0);
            Assert.IsTrue(output);

            
        }
        [TestMethod]
        public void TestToSeeIfParkExists()
        {
            ParkSQLDAL dal = new ParkSQLDAL(connectionString);
            List < Park > p = dal.ShowAllNationalParks();
            bool output = (p.Count > 0);
            Assert.IsTrue(output);

        }

    }
}
