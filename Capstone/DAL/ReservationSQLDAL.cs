using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;
namespace Capstone.DAL
{
  public   class ReservationSQLDAL
    {
        private string connectionString;

        public ReservationSQLDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public List<Reservation> GetAllReservations(int campsiteID)
        {
            List<Reservation> output = new List<Reservation>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from reservation;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reservation r = new Reservation();
                        r.Reservation_ID = Convert.ToInt32(reader["reservation_id"]);
                        r.Site_ID = Convert.ToInt32(reader["site_id"]);
                        r.Name = Convert.ToString(reader["name"]);
                        r.From_Date = Convert.ToDateTime(reader["from_date"]);
                        r.To_Date = Convert.ToDateTime(reader["to_date"]);
                        r.Create_Date = Convert.ToDateTime(reader["create_date"]);

                        output.Add(r);
                    }
                }

            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;
        }
      
        public int  MakeReservation(int siteIdChoice, string reservationName, DateTime fromDate, DateTime toDate)
        {
            //List<Reservation> output = new List<Reservation>();
        
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation (site_id, name, from_date, to_date) VALUES (@siteID, @reservationName, @fromDate, @toDate);", conn); //SQL insert statement goes here
                    cmd.Parameters.AddWithValue("@siteID", siteIdChoice);
                    cmd.Parameters.AddWithValue("@reservationName", reservationName);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    cmd.ExecuteNonQuery();
                    //SqlDataReader reader = cmd.ExecuteReader();


                    cmd = new SqlCommand("Select max(reservation.reservation_id) from reservation;", conn);
                   int reservationReferenceID = (int)(cmd.ExecuteScalar());
                    return reservationReferenceID;


                }
            }
            catch(SqlException ex )
            {
                throw;
            }
           
        }

    }
}
