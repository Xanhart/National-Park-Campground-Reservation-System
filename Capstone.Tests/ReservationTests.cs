using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;
using System.Collections.Generic;
namespace Capstone.Tests
{
    [TestClass]
    public class ReservationTests
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
        public void TestToSeeIfYouCanCreateAReservation()
        {

            ReservationSQLDAL dal = new ReservationSQLDAL(connectionString);
            List<Reservation> r = dal.GetAllReservations(1); // added test campsite
            bool output = (r.Count > 0);
            Assert.IsTrue(output);
        }
    }
}
