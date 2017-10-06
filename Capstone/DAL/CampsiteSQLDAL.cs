using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampsiteSQLDAL
    {
        private string connectionString;

        public CampsiteSQLDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public List<Campsite> GetAllCampsites(int campgroundID)
        {
            List<Campsite> putput = new List<Campsite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from site WHERE campground_id = @campgroundID ;", conn);
                    cmd.Parameters.AddWithValue("@campgroundID", campgroundID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campsite s = new Campsite();
                        s.Site_ID = Convert.ToInt32(reader["site_id"]);
                        s.Campground_ID = Convert.ToInt32(reader["campground_id"]);
                        s.Site_Number = Convert.ToInt32(reader["site_number"]);
                        s.Max_Occupancy = Convert.ToInt32(reader["max_occupancy"]);
                        s.Accessible = Convert.ToBoolean(reader["accessible"]);
                        s.Max_RV_Length = Convert.ToInt32(reader["max_rv_length"]);
                        s.Utilities = Convert.ToBoolean(reader["utilities"]);
                        putput.Add(s);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return putput;
         }
    }
}
