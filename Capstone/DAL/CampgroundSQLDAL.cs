using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAL
{
   public  class CampgroundSQLDAL
    {
        private string connectionString;

        public CampgroundSQLDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

    }
}
