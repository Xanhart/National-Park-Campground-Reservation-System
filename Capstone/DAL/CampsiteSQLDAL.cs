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
            catch (SqlException ex)
            {
                throw;
            }
            return putput;
        }
        public List<Campsite> GetAvailableCampsites(int campgroundchoice, DateTime fromDate, DateTime toDate)
        {
            List<Campsite> putput = new List<Campsite>();
         ;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select top 5 * from site where site.site_id not in (select  site_id from reservation where (from_date > @fromDate AND from_date < @toDate) or (to_date > @fromDate AND to_date < @toDate) or(from_date < @fromDate and from_date > @toDate) and(to_date > @fromDate and to_date < @toDate)) and campground_id = @campgroundID;", conn); //FUXXED 
                    cmd.Parameters.AddWithValue("@campgroundID", campgroundchoice);
                    //cmd.Parameters.AddWithValue("@campsiteID", campsiteID);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);

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
            catch (SqlException ex)
            {
                throw;
            }
            return putput;
        }
    }
}
