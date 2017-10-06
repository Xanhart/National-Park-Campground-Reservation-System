using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampgroundSQLDAL
    {
        private string connectionString;

        public CampgroundSQLDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public List<Campground> GetAllCampgrounds(int Parkid)
        {
            List<Campground> output = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from campground WHERE park_id = @parkID ;", conn);
                    cmd.Parameters.AddWithValue("@parkID", Parkid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground c = new Campground();
                        c.Campground_ID = Convert.ToInt32(reader["campground_id"]);
                        c.Park_ID = Convert.ToInt32(reader["park_id"]);
                        c.Name = Convert.ToString(reader["name"]);
                        c.Open_From_MM = Convert.ToInt32(reader["open_from_mm"]);
                        c.Open_To_MM = Convert.ToInt32(reader["open_to_mm"]);
                        c.Daily_Fee = Convert.ToDecimal(reader["daily_fee"]);
                        output.Add(c);



                    }




                }
             }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        
        }
            




    }
}
