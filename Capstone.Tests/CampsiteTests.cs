using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class CampsiteTests
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
        public void IfCapsitesExist()

        {
            CampsiteSQLDAL dal = new CampsiteSQLDAL(connectionString);
            List<Campsite> c = dal.GetAllCampsites(1); // added campground ID
            bool output = (c.Count > 0);
            Assert.IsTrue(output);
        }
    }
}
