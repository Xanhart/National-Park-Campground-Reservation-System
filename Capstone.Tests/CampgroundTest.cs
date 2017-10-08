using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundTests
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
        public void GetCampgroundWorks()
        {
            CampgroundSQLDAL dal = new CampgroundSQLDAL(connectionString);
            List<Campground> c = dal.GetAllCampgrounds(1); // added park ID
            bool output = (c.Count > 0);
            Assert.IsTrue(output);
        }
    }
}
